using AutoMapper;
using Common.DTOs.TeamDTO;
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
            return _mapper.Map<TeamReadDto>(_unitOfWork.TeamRepository.GetById(id));
        }

        public IEnumerable<TeamReadDto> GetAllTeams()
        {
            return _mapper.Map<IEnumerable<TeamReadDto>>(_unitOfWork.TeamRepository.GetAll());
        }

        public IEnumerable<TeamReadDto> GetAllTeamsIncludingTeamscans(int userId)
        {
            return _mapper.Map<IEnumerable<TeamReadDto>>(_unitOfWork.TeamRepository.GetAllTeamsIncludingTeamscans(userId)); ;
        }
        public IEnumerable<TeamReadDto> GetAllTeamsIncludingTeamMembers(int userId)
        {
            return _mapper.Map<IEnumerable<TeamReadDto>>(_unitOfWork.TeamRepository.GetAllTeamsIncludingTeamMembers(userId)); ;
        }

        public IEnumerable<TeamReadDto> GetAllTeamsByUser(int userId)
        {
            return _mapper.Map<IEnumerable<TeamReadDto>>(_unitOfWork.TeamRepository.GetAllTeamsByUser(userId)); ;
        }

        public TeamReadDto AddTeam(TeamCreateDto teamCreateDto)
        {
            try
            {
                var newTeam = _unitOfWork.TeamRepository.Add(_mapper.Map<Team>(teamCreateDto));
                _unitOfWork.Commit();
                return _mapper.Map<TeamReadDto>(newTeam);
            }
            catch (DbUpdateException ex) when ((ex.InnerException as SqlException)?.Number == 2601)
            {
                _unitOfWork.Rollback();
                throw new Exception($"Team already exists with the name {teamCreateDto.Name}", ex);
            }
        }

        public TeamReadDto UpdateTeam(TeamUpdateDto teamUpdateDto)
        {
            try
            {
                var updatedTeam = _unitOfWork.TeamRepository.UpdateTeam(_mapper.Map<Team>(teamUpdateDto));
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
