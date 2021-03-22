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

        public IEnumerable<InterpretationTranslationReadDto> GetAllInterpretationTranslationsByLevelAndDysfunctions(int languageId, List<InterpretationTranslationRequestDto> list)
        {
            List<InterpretationTranslationReadDto> interprationTranslations = new List<InterpretationTranslationReadDto>();
            foreach (var item in list)
            {
                var interpretation = _unitOfWork.InterpretationRepository.GetInterpretationByLevelAndDysfunction(item.LevelId, item.DysfunctionId);
                var interpretationTranslation = _unitOfWork.InterpretationTranslationRepository.GetInterpretationTranslationByLanguage(interpretation.Id, languageId);
                interprationTranslations.Add(_mapper.Map<InterpretationTranslationReadDto>(interpretationTranslation));
            }
            return interprationTranslations;
        }
    }
}
