using AutoMapper;
using Common.DTOs.TeamDTO;
using DAL.Models;
using DAL.Repositories;
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

        public IEnumerable<TeamReadDto> GetAllTeamsWithTeamscans(int userId)
        {
            return _mapper.Map<IEnumerable<TeamReadDto>>(_unitOfWork.TeamRepository.GetAllTeamsWithTeamscans(userId)); ;
        }

        public IEnumerable<TeamReadDto> GetAllTeamsByUser(int userId)
        {
            return _mapper.Map<IEnumerable<TeamReadDto>>(_unitOfWork.TeamRepository.GetAllTeamsByUser(userId)); ;
        }

        public TeamReadDto AddTeam(TeamCreateDto teamCreateDto)
        {
            var newTeam = _unitOfWork.TeamRepository.Add(_mapper.Map<Team>(teamCreateDto));
            _unitOfWork.Commit();
            return _mapper.Map<TeamReadDto>(newTeam);
        }

        public TeamReadDto UpdateTeam(TeamUpdateDto teamUpdateDto)
        {
            var updatedTeam =_unitOfWork.TeamRepository.Update(_mapper.Map<Team>(teamUpdateDto));
            _unitOfWork.Commit();
            return _mapper.Map<TeamReadDto>(updatedTeam);
        }

        public void DeleteTeam(int id)
        {
            _unitOfWork.TeamRepository.Delete(id);
            _unitOfWork.Commit();
        }       
    }
}
