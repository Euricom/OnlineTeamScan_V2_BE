using AutoMapper;
using Common.DTOs.RecommendationTranslationDTO;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.RecommendationTranslationServices
{
    public class RecommendationTranslationService : IRecommendationTranslationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RecommendationTranslationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<RecommendationTranslationReadDto> GetAllRecommendationTranslationByLanguageId(int languageId)
        {
            var recommendations = _unitOfWork.RecommendationTranslationRepository.GetAllRecommendationTranslationByLanguageId(languageId);

            if (recommendations == null)
                return null;

            return _mapper.Map<IEnumerable<RecommendationTranslationReadDto>>(recommendations);
        }
    }
}
