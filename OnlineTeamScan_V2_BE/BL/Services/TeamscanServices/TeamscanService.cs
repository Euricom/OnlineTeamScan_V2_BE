using AutoMapper;
using BL.Mail;
using BL.MailTemplates;
using Common.DTOs.IndividualScoreDTO;
using Common.DTOs.TeamDTO;
using Common.DTOs.TeamscanDTO;
using DAL.Models;
using DAL.Repositories;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.TeamscanServices
{
    public class TeamscanService : ITeamscanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeamscanService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public TeamscanReadDto GetTeamscanById(int id)
        {
            var teamscan = _unitOfWork.TeamscanRepository.GetById(id);

            if (teamscan == null)
                return null;

            return _mapper.Map<TeamscanReadDto>(teamscan);      
        }

        public IEnumerable<TeamscanReadDto> GetAllTeamscansByTeam(int teamId)
        {
            var teamscan = _unitOfWork.TeamscanRepository.GetAllTeamscansByTeam(teamId);

            if (teamscan == null)
                return null;

            return _mapper.Map<IEnumerable<TeamscanReadDto>>(teamscan);
        }

        public TeamscanReadDto GetPreviousTeamscan(int id)
        {
            var teamscan = _unitOfWork.TeamscanRepository.GetById(id);

            if (teamscan != null)
                return _mapper.Map<TeamscanReadDto>(_unitOfWork.TeamscanRepository.GetPreviousTeamscan(teamscan.TeamId, teamscan.Number - 1));

            return null;
        }

        public TeamReadDto AddTeamscan(int startedById, int teamId)
        {
            var checkteam = _unitOfWork.TeamRepository.GetById(teamId);
            if (checkteam.IsTeamscanActive)
                throw new Exception("There is already a teamscan active");

            try
            {
                var newTeamscan = CreateTeamscan(startedById, teamId);
                CreateInvidualScores(newTeamscan);
                var updatedTeam = SetTeamscanActive(teamId);
                _unitOfWork.Commit();

                return _mapper.Map<TeamReadDto>(updatedTeam);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception("Something went wrong", ex);
            }
        }

        public Teamscan CreateTeamscan(int startedById, int teamId)
        {
            int? teamscanNumber = _unitOfWork.TeamscanRepository.GetLatestTeamscanNumber(teamId);
            int newNumber = teamscanNumber != null ? (int)teamscanNumber + 1 : 1;

            var newTeamscan = new TeamscanCreateDto
            {
                Title = $"Teamscan {newNumber}",
                StartedById = startedById,
                TeamId = teamId,
                Number = newNumber,
                StartDate = DateTime.Today
            };

            var addedTeamscan = _unitOfWork.TeamscanRepository.Add(_mapper.Map<Teamscan>(newTeamscan));
            _unitOfWork.Commit();

            return addedTeamscan;
        }

        public void CreateInvidualScores(Teamscan teamscan)
        {
            IEnumerable<TeamMember> activeTeamMemberList = _unitOfWork.TeamMemberRepository.GetAllActiveTeamMembersByTeam(teamscan.TeamId);
            var team = _unitOfWork.TeamRepository.GetById(teamscan.TeamId);
            var teamleader = _unitOfWork.UserRepository.GetById(team.TeamleaderId);

            foreach (TeamMember teamMember in activeTeamMemberList)
            {
                var newIndividualScore = new IndividualScoreCreateDto
                {
                    Id = Guid.NewGuid(),
                    TeamMemberId = teamMember.Id,
                    TeamscanId = teamscan.Id
                };

                _unitOfWork.IndividualScoreRepository.Add(_mapper.Map<IndividualScore>(newIndividualScore));

                if(teamMember.Email != teamleader.Email)
                {
                    Mailer.InviteTeamscan(teamMember, team, teamleader, newIndividualScore.Id).Wait();
                }    
            }
        }

        public TeamReadDto SetTeamscanActive(int teamId)
        {
            var teamToUpdate = _unitOfWork.TeamRepository.GetById(teamId);

            if (teamToUpdate == null)
                throw new Exception($"Team with id {teamId} not found.");

            var updatedteam = _unitOfWork.TeamRepository.UpdateIsTeamscanActive(teamToUpdate);
            return _mapper.Map<TeamReadDto>(updatedteam);
        }
    }
}
