using AutoMapper;
using Common.DTOs.TeamscanDTO;
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

        public TeamscanReadDto GetTeamscanById(int id)
        {
            var teamscan = _unitOfWOrk.TeamscanRepository.GetById(id);

            if (teamscan == null)
                return null;

            return _mapper.Map<TeamscanReadDto>(teamscan);      
        }

        public IEnumerable<TeamscanReadDto> GetAllTeamscansByTeam(int teamId)
        {
            var teamscan = _unitOfWOrk.TeamscanRepository.GetAllTeamscansByTeam(teamId);

            if (teamscan == null)
                return null;

            return _mapper.Map<IEnumerable<TeamscanReadDto>>(teamscan);
        }

        public TeamscanReadDto GetPreviousTeamscan(int id)
        {
            var teamscan = _unitOfWOrk.TeamscanRepository.GetById(id);

            if (teamscan != null)
                return _mapper.Map<TeamscanReadDto>(_unitOfWOrk.TeamscanRepository.GetPreviousTeamscan(teamscan.TeamId, teamscan.Number - 1));

            return null;
        }

    }
}
