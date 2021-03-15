using AutoMapper;
using Common.DTOs.AnswerDTO;
using Common.DTOs.IndividualScoreDTO;
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

        public IndividualScoreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IndividualScoreReadDto GetIndividualScoreById(int id)
        {
            return _mapper.Map<IndividualScoreReadDto>(_unitOfWork.IndividualScoreRepository.GetById(id));
        }

        public IEnumerable<IndividualScoreReadDto> GetAllIndividualScores()
        {
            return _mapper.Map<IEnumerable<IndividualScoreReadDto>>(_unitOfWork.IndividualScoreRepository.GetAll());
        }
      
        public IndividualScoreReadDto AddIndividualScore(int teamMemberId, int teamscanId, List<AnswerReadDto> list)
        {
            int sumTrust = 0, sumConflict = 0, sumCommitment = 0, sumAccountability = 0, sumResults = 0;

            int totalTrust = list.Where(item => item.DysfunctionId == 1).Count();
            int totalConflict = list.Where(item => item.DysfunctionId == 2).Count();
            int totalCommitment = list.Where(item => item.DysfunctionId == 3).Count();
            int totalAccountability = list.Where(item => item.DysfunctionId == 4).Count();
            int totalResults = list.Where(item => item.DysfunctionId == 5).Count();

            foreach (var item in list)
            {
                switch (item.DysfunctionId)
                {
                    case 1:
                        sumTrust += item.Score;
                        break;
                    case 2:
                        sumConflict += item.Score;
                        break;
                    case 3:
                        sumCommitment += item.Score;
                        break;
                    case 4:
                        sumAccountability += item.Score;
                        break;
                    case 5:
                        sumResults += item.Score;
                        break;
                }
            }

            IndividualScoreCreateDto individualScoreCreateDto = new IndividualScoreCreateDto
            {
                TeamMemberId = teamMemberId,
                TeamscanId = teamscanId,
                ScoreTrust = totalTrust != 0 ? Math.Round((decimal)sumTrust / totalTrust, 2) : 0,
                ScoreConflict = totalConflict != 0 ? Math.Round((decimal)sumConflict / totalConflict, 2) : 0,
                ScoreCommitment = totalCommitment != 0 ? Math.Round((decimal)sumCommitment / totalCommitment, 2) : 0,
                ScoreAccountability = totalAccountability != 0 ? Math.Round((decimal)sumAccountability / totalAccountability, 2) : 0,
                ScoreResults = totalResults != 0 ? Math.Round((decimal)sumResults / totalResults, 2) : 0
            };

            try
            {
                var newIndividualScore = _unitOfWork.IndividualScoreRepository.Add(_mapper.Map<IndividualScore>(individualScoreCreateDto));
                _unitOfWork.Commit();
                return _mapper.Map<IndividualScoreReadDto>(newIndividualScore);
            }
            catch (DbUpdateException ex) when ((ex.InnerException as SqlException)?.Number == 547)
            {
                _unitOfWork.Rollback();
                throw new Exception($"Please enter a valid teamscanid and teammemberid", ex);
            }
            catch (DbUpdateException ex) when ((ex.InnerException as SqlException)?.Number == 2601)
            {
                _unitOfWork.Rollback();
                throw new Exception($"Cannot have a duplicate score with teammemberid {teamMemberId} and teamscanid {teamscanId}", ex);
            }
        }

        public void CalculateTeamscore(int teamscanId)
        {
            var individualScores = _unitOfWork.IndividualScoreRepository.GetAllByTeamscan(teamscanId);
            int totalScores = individualScores.Count();
            decimal sumTrust = 0, sumConflict = 0, sumCommitment = 0, sumAccountability = 0, sumResults = 0;

            individualScores.ToList().ForEach(i => sumTrust += i.ScoreTrust);
            individualScores.ToList().ForEach(i => sumConflict += i.ScoreConflict);
            individualScores.ToList().ForEach(i => sumCommitment += i.ScoreCommitment);
            individualScores.ToList().ForEach(i => sumAccountability += i.ScoreAccountability);
            individualScores.ToList().ForEach(i => sumResults += i.ScoreResults);

            TeamscanUpdateDto teamscanUpdateDto = new TeamscanUpdateDto
            {
                Id = teamscanId,
                ScoreTrust = Math.Round(sumTrust / totalScores, 2),
                ScoreConflict = Math.Round(sumConflict / totalScores, 2),
                ScoreCommitment = Math.Round(sumCommitment / totalScores, 2),
                ScoreAccountability = Math.Round(sumAccountability / totalScores, 2),
                ScoreResults = Math.Round(sumResults / totalScores, 2)
            };

            _unitOfWork.TeamscanRepository.UpdateScores(_mapper.Map<Teamscan>(teamscanUpdateDto));
            _unitOfWork.Commit();
        }
    }
}
