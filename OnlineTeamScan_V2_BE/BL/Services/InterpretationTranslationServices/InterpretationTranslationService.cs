using AutoMapper;
using Common.DTOs.InterpretationTranslationDTO;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.InterpretationTranslationServices
{
    public class InterpretationTranslationService : IInterpretationTranslationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InterpretationTranslationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public InterpretationTranslationReadDto GetInterpretationTranslationByLevelAndDysfunction(int languageId, int levelId, int dysfunctionId)
        {
            var interpretation = _unitOfWork.InterpretationRepository.GetInterpretationByLevelAndDysfunction(levelId, dysfunctionId);
            var interpretationTranslation = _unitOfWork.InterpretationTranslationRepository.GetInterpretationTranslationByLanguage(interpretation.Id, languageId);

            return _mapper.Map<InterpretationTranslationReadDto>(interpretationTranslation);
        }
    }
}
