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

        public IEnumerable<TeamscanReadDto> GetAllTeamscansByTeam(int teamId)
        {
            return _mapper.Map<IEnumerable<TeamscanReadDto>>(_unitOfWOrk.TeamscanRepository.GetAllTeamscansByTeam(teamId));
        }
    }
}
