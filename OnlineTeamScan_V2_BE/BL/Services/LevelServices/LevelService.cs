using AutoMapper;
using Common.DTOs.LevelDTO;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.LevelServices
{
    public class LevelService : ILevelService
    {
        private readonly IUnitOfWork _unitOfWOrk;
        private readonly IMapper _mapper;

        public LevelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWOrk = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<LevelReadDto> GetAllLevels()
        {
            var levels = _unitOfWOrk.LevelRepository.GetAll();

            if (levels == null)
                return null;

            return _mapper.Map<IEnumerable<LevelReadDto>>(levels);
        }
    }
}
