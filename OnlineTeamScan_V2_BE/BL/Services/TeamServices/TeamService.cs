using Common.DTOs.TeamDTO;
using DAL.Repositories;
using DAL.Repositories.TeamRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.TeamServices
{
    public class TeamService : ITeamService
    {
        /*private readonly ITeamRepository _repository;

        public TeamService(ITeamRepository repository)
        {
            _repository = repository;
        }*/

        private readonly IUnitOfWork _unitOfWork;

        public TeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TeamReadDto GetTeamById(int id)
        {
            return _unitOfWork.TeamRepository.GetById(id);
        }

        public IEnumerable<TeamReadDto> GetAllTeams()
        {
            return _unitOfWork.TeamRepository.GetAll();
        }

        public TeamReadDto AddTeam(TeamCreateDto teamCreateDto)
        {
            return _unitOfWork.TeamRepository.Add(teamCreateDto);
        }

        public TeamReadDto UpdateTeam(TeamUpdateDto teamUpdateDto)
        {
            return _unitOfWork.TeamRepository.Update(teamUpdateDto);
        }

        public void DeleteTeam(int id)
        {
            _unitOfWork.TeamRepository.Delete(id);
        }
    }
}
