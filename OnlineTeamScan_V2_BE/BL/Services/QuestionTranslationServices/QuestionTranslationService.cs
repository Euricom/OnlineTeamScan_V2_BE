using AutoMapper;
using Common.DTOs.QuestionTranslationDTO;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.QuestionTranslationServices
{
    public class QuestionTranslationService : IQuestionTranslationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionTranslationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<QuestionTranslationReadDto> GetAllQuestionsByLanguage(int languageId)
        {
            var questions = _unitOfWork.QuestionTranslationRepository.GetAllQuestionsByLanguage(languageId);

            if (questions == null)
                return null;

            return _mapper.Map<IEnumerable<QuestionTranslationReadDto>>(questions);
        }
    }
}
