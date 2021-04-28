using AutoMapper;
using Common.DTOs.TeamDTO;
using Common.DTOs.TeamMemberDTO;
using DAL.Models;
using DAL.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.TeamServices
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public TeamReadDto GetTeamById(int id)
        {
            var team = _unitOfWork.TeamRepository.GetById(id);

            if (team == null)
                return null;

            return _mapper.Map<TeamReadDto>(team);
        }

        public TeamReadDto GetFullTeamById(int userId, int id)
        {
            var team = _unitOfWork.TeamRepository.GetFullTeamById(id);

            if (team == null || team.TeamleaderId != userId)
                return null;

            return _mapper.Map<TeamReadDto>(team);
        }

        public IEnumerable<TeamReadDto> GetAllTeamsByUserIncludingTeamscans(int userId)
        {
            var teams = _unitOfWork.TeamRepository.GetAllTeamsByUserIncludingTeamscans(userId);

            if (teams == null)
                return null;

            return _mapper.Map<IEnumerable<TeamReadDto>>(teams);
        }

        public IEnumerable<TeamReadDto> GetAllTeamsByUserIncludingTeamMembers(int userId)
        {
            var teams = _unitOfWork.TeamRepository.GetAllTeamsByUserIncludingTeamMembers(userId);

            if (teams == null)
                return null;

            return _mapper.Map<IEnumerable<TeamReadDto>>(teams);
        }

        public IEnumerable<TeamReadDto> GetAllTeamsByUser(int userId)
        {
            var teams = _unitOfWork.TeamRepository.GetAllTeamsByUser(userId);

            if (teams == null)
                return null;

            return _mapper.Map<IEnumerable<TeamReadDto>>(teams);
        }

        public TeamReadDto AddTeam(TeamCreateDto teamCreateDto)
        {
            try
            {
                var newTeam = _unitOfWork.TeamRepository.Add(_mapper.Map<Team>(teamCreateDto)); 
                _unitOfWork.Commit();
                var user = _unitOfWork.UserRepository.GetById(teamCreateDto.TeamleaderId);
                var newTeamMember = new TeamMemberCreateDto
                {
                    Email = user.Email,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    TeamId = newTeam.Id
                };
                _unitOfWork.TeamMemberRepository.Add(_mapper.Map<TeamMember>(newTeamMember));
                _unitOfWork.Commit();
                return _mapper.Map<TeamReadDto>(newTeam);
            }
            catch (DbUpdateException ex) when ((ex.InnerException as SqlException)?.Number == 2601)
            {
                _unitOfWork.Rollback();
                throw new Exception($"Team already exists with the name {teamCreateDto.Name}", ex);
            }
        }

        public TeamReadDto UpdateTeamName(TeamUpdateDto teamUpdateDto)
        {
            try
            {
                var updatedTeam = _unitOfWork.TeamRepository.UpdateTeamName(_mapper.Map<Team>(teamUpdateDto));
                _unitOfWork.Commit();
                return _mapper.Map<TeamReadDto>(updatedTeam);
            }
            catch (DbUpdateException ex) when ((ex.InnerException as SqlException)?.Number == 2601)
            {
                _unitOfWork.Rollback();
                throw new Exception($"Team already exists with the name {teamUpdateDto.Name}", ex);
            }       
        }

        public void DeleteTeam(int id)
        {
            _unitOfWork.TeamRepository.Delete(id);
            _unitOfWork.Commit();
        }
    }
}
