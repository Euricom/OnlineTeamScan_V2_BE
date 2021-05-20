using AutoMapper;
using BL.Mail;
using Common.DTOs.AnswerDTO;
using Common.DTOs.IndividualScoreDTO;
using Common.DTOs.TeamDTO;
using Common.DTOs.TeamscanDTO;
using DAL.Models;
using DAL.Repositories;
using DAL.Repositories.IndividualScoreRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.IndividualScoreServices
{
    public class IndividualScoreService : IIndividualScoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Mailer _mailer;

        public IndividualScoreService(IUnitOfWork unitOfWork, IMapper mapper, Mailer mailer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mailer = mailer;
        }

        public IEnumerable<IndividualScoreReadDto> GetAllIndividualScoresByTeamscanWithTeamMembers(int teamscanId)
        {
            var individualScores = _unitOfWork.IndividualScoreRepository.GetAllIndividualScoresByTeamscanWithTeamMembers(teamscanId);

            if (individualScores == null)
                return null;

            return _mapper.Map<IEnumerable<IndividualScoreReadDto>>(individualScores);
        }

        public IndividualScoreReadDto GetIndividualScoreByIdIncludingTeamscan(Guid id)
        {
            var individualScore = _unitOfWork.IndividualScoreRepository.GetIndividualScoreByIdIncludingTeamscan(id);

            if (individualScore == null)
                return null;

            return _mapper.Map<IndividualScoreReadDto>(individualScore);
        }

        public IndividualScoreReadDto GetIndividualScoreById(Guid id)
        {
            var individualScore = _unitOfWork.IndividualScoreRepository.GetIndividualScoreById(id);

            if (individualScore == null)
                return null;

            return _mapper.Map<IndividualScoreReadDto>(individualScore);
        }

        public IndividualScoreReadDto UpdateIndividualScore(Guid id, List<AnswerReadDto> list)
        {
            var individualScoreToUpdate = _unitOfWork.IndividualScoreRepository.GetIndividualScoreById(id);

            if (individualScoreToUpdate == null)
                throw new Exception($"Individual score not found");

            if (individualScoreToUpdate.HasAnswered == true)
                throw new Exception($"This team member has already answered the teamscan");

            var calculatedIndividualScore = CalculateIndividualScore(individualScoreToUpdate.Id, list);

            try
            {
                var updatedIndividualScore = _unitOfWork.IndividualScoreRepository.UpdateIndividualScore(_mapper.Map<IndividualScore>(calculatedIndividualScore));
                UpdateTeamscore(individualScoreToUpdate.TeamscanId, updatedIndividualScore);
                _unitOfWork.Commit();
                return _mapper.Map<IndividualScoreReadDto>(updatedIndividualScore);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception($"Something went wrong while updating the individual score", ex);
            }
        }

        public void UpdateTeamscore(int teamscanId, IndividualScore updatedScore)
        {
            var teamscanToUpdate = _unitOfWork.TeamscanRepository.GetById(teamscanId);

            if (teamscanToUpdate == null)
                throw new Exception($"Teamscan not found");

            if (teamscanToUpdate.EndDate != null)
                throw new Exception($"Teamscan is finished");

            var notAnsweredList = _unitOfWork.IndividualScoreRepository.GetAll(score => score.HasAnswered == false && score.TeamscanId == teamscanId && score.Id != updatedScore.Id);
            bool isTeamscanFinished = notAnsweredList.Count() == 0 ? true : false;

            var calculatedTeamscan = CalculateTeamscore(teamscanId, updatedScore, isTeamscanFinished);
            _unitOfWork.TeamscanRepository.UpdateScores(_mapper.Map<Teamscan>(calculatedTeamscan));

            if (isTeamscanFinished)
                UpdateLastTeamscanOfTeam(teamscanToUpdate.TeamId, calculatedTeamscan.EndDate, teamscanId);
        }

        public void UpdateLastTeamscanOfTeam(int teamId, DateTime? endDate, int teamscanId)
        {
            var team = _unitOfWork.TeamRepository.GetById(teamId);
            team.IsTeamscanActive = false;
            team.LastTeamScan = endDate;

            var teamleader = _unitOfWork.UserRepository.GetById(team.TeamleaderId);

            _mailer.CompletedTeamscan(team.Name, teamleader, teamscanId).Wait();

            _unitOfWork.TeamRepository.UpdateLastTeamscanOfTeam(_mapper.Map<Team>(team));
        }

        public TeamscanUpdateDto CalculateTeamscore(int teamscanId, IndividualScore updatedScore, bool isTeamscanFinished)
        {
            decimal sumTrust = 0, sumConflict = 0, sumCommitment = 0, sumAccountability = 0, sumResults = 0;
            var individualScores = _unitOfWork.IndividualScoreRepository.GetAllAnsweredByTeamscan(teamscanId).ToList();
            individualScores.Add(updatedScore);
            int totalScores = individualScores.Count();

            individualScores.ForEach(score => sumTrust += score.ScoreTrust);
            individualScores.ForEach(score => sumConflict += score.ScoreConflict);
            individualScores.ForEach(score => sumCommitment += score.ScoreCommitment);
            individualScores.ForEach(score => sumAccountability += score.ScoreAccountability);
            individualScores.ForEach(score => sumResults += score.ScoreResults);

            TeamscanUpdateDto teamscanUpdateDto = new TeamscanUpdateDto
            {
                Id = teamscanId,
                EndDate = isTeamscanFinished ? DateTime.Today : null,
                ScoreTrust = totalScores != 0 ? Math.Round(sumTrust / totalScores, 2) : 0,
                ScoreConflict = totalScores != 0 ? Math.Round(sumConflict / totalScores, 2) : 0,
                ScoreCommitment = totalScores != 0 ? Math.Round(sumCommitment / totalScores, 2) : 0,
                ScoreAccountability = totalScores != 0 ? Math.Round(sumAccountability / totalScores, 2) : 0,
                ScoreResults = totalScores != 0 ? Math.Round(sumResults / totalScores, 2) : 0
            };

            return teamscanUpdateDto;
        }

        public IndividualScoreUpdateDto CalculateIndividualScore(Guid id, List<AnswerReadDto> list)
        {
            decimal sumTrust = 0, sumConflict = 0, sumCommitment = 0, sumAccountability = 0, sumResults = 0;

            int totalTrust = list.Where(item => item.DysfunctionId == 1).Count();
            int totalConflict = list.Where(item => item.DysfunctionId == 2).Count();
            int totalCommitment = list.Where(item => item.DysfunctionId == 3).Count();
            int totalAccountability = list.Where(item => item.DysfunctionId == 4).Count();
            int totalResults = list.Where(item => item.DysfunctionId == 5).Count();

            foreach (var answer in list)
            {
                switch (answer.DysfunctionId)
                {
                    case 1:
                        sumTrust += answer.Score;
                        break;
                    case 2:
                        sumConflict += answer.Score;
                        break;
                    case 3:
                        sumCommitment += answer.Score;
                        break;
                    case 4:
                        sumAccountability += answer.Score;
                        break;
                    case 5:
                        sumResults += answer.Score;
                        break;
                }
            }

            IndividualScoreUpdateDto individualScoreUpdateDto = new IndividualScoreUpdateDto

            {
                Id = id,
                HasAnswered = true,
                ScoreTrust = totalTrust != 0 ? Math.Round(sumTrust / totalTrust, 2) : 0,
                ScoreConflict = totalConflict != 0 ? Math.Round(sumConflict / totalConflict, 2) : 0,
                ScoreCommitment = totalCommitment != 0 ? Math.Round(sumCommitment / totalCommitment, 2) : 0,
                ScoreAccountability = totalAccountability != 0 ? Math.Round(sumAccountability / totalAccountability, 2) : 0,
                ScoreResults = totalResults != 0 ? Math.Round(sumResults / totalResults, 2) : 0
            };

            return individualScoreUpdateDto;
        }
    }
}
