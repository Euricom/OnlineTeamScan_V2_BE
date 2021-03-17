using AutoMapper;
using Common.DTOs.DysfunctionTranslationDTO;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.DysfunctionTranslationServices
{
    public class DysfunctionTranslationService : IDysfunctionTranslationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DysfunctionTranslationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<DysfunctionTranslationReadDto> GetAllDysfunctionsByLanguage(int languageId)
        {
            return _mapper.Map<IEnumerable<DysfunctionTranslationReadDto>>(_unitOfWork.DysfunctionTranslationRepository.GetAllDysfunctionsByLanguage(languageId));
        }
    }
}
