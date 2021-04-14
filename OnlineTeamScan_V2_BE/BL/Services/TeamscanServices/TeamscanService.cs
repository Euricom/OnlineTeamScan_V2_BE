using AutoMapper;
using Common.DTOs.TeamDTO;
using Common.DTOs.TeamscanDTO;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.TeamscanServices
{
    public class TeamscanService : ITeamscanService
    {
        private readonly IUnitOfWork _unitOfWOrk;
        private readonly IMapper _mapper;

        public TeamscanService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWOrk = unitOfWork;
            _mapper = mapper;
        }

        public TeamscanReadDto GetTeamscanById(int teamscanId)
        {
            return _mapper.Map<TeamscanReadDto>(_unitOfWOrk.TeamscanRepository.GetById(teamscanId));
        }

        public IEnumerable<TeamscanReadDto> GetAllTeamscansByTeam(int teamId)
        {
            return _mapper.Map<IEnumerable<TeamscanReadDto>>(_unitOfWOrk.TeamscanRepository.GetAllTeamscansByTeam(teamId));
        }

        public TeamscanReadDto GetPreviousTeamscan(int teamscanId)
        {
            var teamscan = _unitOfWOrk.TeamscanRepository.GetById(teamscanId);

            if (teamscan != null)
            {
                return _mapper.Map<TeamscanReadDto>(_unitOfWOrk.TeamscanRepository.GetPreviousTeamscan(teamscan.TeamId, teamscan.Number - 1));
            }

            return null;
        }

        public TeamReadDto AddTeamscan(int startedById, int teamId)
        {
            try
            {
                var newTeamscan = CreateTeamscan(startedById, teamId);
                CreateInvidualScores(newTeamscan);
                var updatedTeam = SetTeamscanActive(teamId);
                _unitOfWOrk.Commit();

                return _mapper.Map<TeamReadDto>(updatedTeam);
            }
            catch (Exception ex)
            {
                _unitOfWOrk.Rollback();
                throw new Exception("Something went wrong", ex);
            }
        }

        public Teamscan CreateTeamscan(int startedById, int teamId)
        {
            int? teamscanNumber = _unitOfWOrk.TeamscanRepository.GetLatestTeamscanNumber(teamId);
            int newNumber = teamscanNumber != null ? (int)teamscanNumber + 1 : 1;

            var newTeamscan = new TeamscanCreateDto
            {
                Title = $"Teamscan {newNumber}",
                StartedById = startedById,
                TeamId = teamId,
                Number = newNumber,
                StartDate = DateTime.Today
            };

            var addedTeamscan = _unitOfWOrk.TeamscanRepository.Add(_mapper.Map<Teamscan>(newTeamscan));
            _unitOfWOrk.Commit();

            return addedTeamscan;
        }

        public void CreateInvidualScores(Teamscan teamscan)
        {
            IEnumerable<TeamMember> activeTeamMemberList = _unitOfWOrk.TeamMemberRepository.GetAllActiveTeamMembersByTeam(teamscan.TeamId);

            foreach (TeamMember teamMember in activeTeamMemberList)
            {
                var newIndividualScore = new IndividualScore
                {
                    TeamMemberId = teamMember.Id,
                    TeamscanId = teamscan.Id
                };
                _unitOfWOrk.IndividualScoreRepository.Add(newIndividualScore);
            }
        }

        public TeamReadDto SetTeamscanActive(int teamId)
        {
            var teamToUpdate = _unitOfWOrk.TeamRepository.GetById(teamId);

            if (teamToUpdate == null)
                throw new Exception($"Team with id {teamId} not found.");

            var updatedteam = _unitOfWOrk.TeamRepository.UpdateIsTeamscanActive(teamToUpdate);
            return _mapper.Map<TeamReadDto>(updatedteam);
        }
    }
}
