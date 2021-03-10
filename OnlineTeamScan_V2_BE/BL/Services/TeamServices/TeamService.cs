using Common.DTOs.TeamDTO;
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
        private readonly ITeamRepository _repository;

        public TeamService(ITeamRepository repository)
        {
            _repository = repository;
        }

        public TeamReadDto GetTeamById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TeamReadDto> GetAllTeams()
        {
            return _repository.GetAll();
        }

        public TeamReadDto AddTeam(TeamCreateDto teamCreateDto)
        {
            return _repository.Add(teamCreateDto);
        }

        public TeamReadDto UpdateTeam(TeamUpdateDto teamUpdateDto)
        {
            return _repository.Update(teamUpdateDto);
        }

        public void DeleteTeam(int id)
        {
            _repository.Delete(id);
        }
    }
}
