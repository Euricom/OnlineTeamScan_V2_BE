using AutoMapper;
using Common.DTOs.InterpretationTranslationDTO;
using DAL.Models;
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

        public IEnumerable<InterpretationTranslationReadDto> GetAllInterpretationTranslationsByLevelAndDysfunction(int languageId, int teamscanId)
        {                    
            var teamscan = _unitOfWork.TeamscanRepository.GetById(teamscanId);
            var dysfunctions = _unitOfWork.DysfunctionRepository.GetAll().ToList();
            var levels = _unitOfWork.LevelRepository.GetAll().ToList();

            int trustDysfunctionId = dysfunctions[0].Id, 
                conflictDysfunctionId = dysfunctions[1].Id,
                commitmentDysfunctionId = dysfunctions[2].Id, 
                accountabilityDysfunctionId = dysfunctions[3].Id, 
                resultsDysfunctionId = dysfunctions[4].Id;
           
            int trustLevelId = CalculateLevel(teamscan.ScoreTrust, levels), 
                conflictLevelId = CalculateLevel(teamscan.ScoreConflict, levels), 
                commitmentLevelId = CalculateLevel(teamscan.ScoreCommitment, levels), 
                accountabilityLevelId = CalculateLevel(teamscan.ScoreAccountability, levels), 
                resultsLevelId = CalculateLevel(teamscan.ScoreResults, levels);

            var trustInterpretation = _unitOfWork.InterpretationTranslationRepository.GetTranslatedInterpretationTranslationByLevelAndDysfunction(trustLevelId, trustDysfunctionId, languageId);
            var conflictInterpretation = _unitOfWork.InterpretationTranslationRepository.GetTranslatedInterpretationTranslationByLevelAndDysfunction(conflictLevelId, conflictDysfunctionId, languageId);
            var commitmentInterpretation = _unitOfWork.InterpretationTranslationRepository.GetTranslatedInterpretationTranslationByLevelAndDysfunction(commitmentLevelId, commitmentDysfunctionId, languageId);
            var accountabilityInterpretation = _unitOfWork.InterpretationTranslationRepository.GetTranslatedInterpretationTranslationByLevelAndDysfunction(accountabilityLevelId, accountabilityDysfunctionId, languageId);
            var resultsInterpretation = _unitOfWork.InterpretationTranslationRepository.GetTranslatedInterpretationTranslationByLevelAndDysfunction(resultsLevelId, resultsDysfunctionId, languageId);

            var list = new List<InterpretationTranslation>() { trustInterpretation, conflictInterpretation, commitmentInterpretation, accountabilityInterpretation, resultsInterpretation };
            var interpretationTranslations = _mapper.Map<IEnumerable<InterpretationTranslationReadDto>>(list);
            return interpretationTranslations;
        }

        public int CalculateLevel(decimal score, List<Level> levels)
        {
            int levelId;
            var lowLevel = levels[0];
            var midLevel = levels[1];
            var highLevel = levels[2];
            var defaultLevel = levels[3];

            if (score >= lowLevel.LowerLimit && score <= lowLevel.UpperLimit) return lowLevel.Id;
            if (score >= midLevel.LowerLimit && score <= midLevel.UpperLimit) return midLevel.Id;
            if (score >= highLevel.LowerLimit && score <= highLevel.UpperLimit) return midLevel.Id;
            return defaultLevel.Id;
        }
    }
}
