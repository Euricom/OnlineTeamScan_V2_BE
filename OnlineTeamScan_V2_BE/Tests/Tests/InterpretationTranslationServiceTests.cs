using AutoMapper;
using BL.Services.InterpretationTranslationServices;
using Common.DTOs.InterpretationDTO;
using DAL.Models;
using DAL.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Tests
{
    public class InterpretationTranslationServiceTests
    {
        private readonly InterpretationTranslationService _service;
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();
        private readonly IMapper _mapper = MapperConfig.Initialize();

        private readonly int languageId = 1;
        private readonly int teamscanId = 1;
        private readonly int teamscanNumber = 1;
        private readonly int teamId = 1;
        private readonly int startedById = 1;
        private readonly string text = "This is a test.";
        private readonly int trustInterpretationId = 1;
        private readonly int conflictInterpretationId = 4;
        private readonly int commitmentInterpretationId = 9;
        private readonly int accountabilityInterpretationId = 10;
        private readonly int resultsInterpretationId = 15;

        private readonly Level lowLevel = new Level { Id = 1, LowerLimit = 1m, UpperLimit = 3.24m, Color = "#F95656" };
        private readonly Level mediumLevel = new Level { Id = 2, LowerLimit = 3.25m, UpperLimit = 3.74m, Color = "#FFD54A" };
        private readonly Level highLevel = new Level { Id = 3, LowerLimit = 3.75m, UpperLimit = 5m, Color = "#93EB5F" };
        private readonly Level defaultLevel = new Level { Id = 4, LowerLimit = 0m, UpperLimit = 0m, Color = "#D8D8D8" };

        private readonly List<Dysfunction> dysfunctions = new List<Dysfunction>() 
        { 
            new Dysfunction { Id = 1 },
            new Dysfunction { Id = 2 },
            new Dysfunction { Id = 3 },
            new Dysfunction { Id = 4 },
            new Dysfunction { Id = 5 }
        };

        public InterpretationTranslationServiceTests()
        {
            _service = new InterpretationTranslationService(_unitOfWork.Object, _mapper);
        }

        [Fact]
        public void CalculateLevel_ShouldReturnLowLevelId_WhenBetweenLowLimits()
        {
            var score = 1m;
            var list = new List<Level>() { lowLevel, mediumLevel, highLevel, defaultLevel };

            var result = _service.CalculateLevel(score, list);

            Assert.Equal(lowLevel.Id, result);
        }

        [Fact]
        public void CalculateLevel_ShouldReturnMediumLevelId_WhenBetweenMediumLimits()
        {
            var score = 3.5m;
            var list = new List<Level>() { lowLevel, mediumLevel, highLevel, defaultLevel };

            var result = _service.CalculateLevel(score, list);

            Assert.Equal(mediumLevel.Id, result);
        }

        [Fact]
        public void CalculateLevel_ShouldReturnHighLevelId_WhenBetweenHighLimits()
        {
            var score = 4m;
            var list = new List<Level>() { lowLevel, mediumLevel, highLevel, defaultLevel };

            var result = _service.CalculateLevel(score, list);

            Assert.Equal(highLevel.Id, result);
        }

        [Fact]
        public void CalculateLevel_ShouldReturnDefaultLevelId_WhenBetweenDefaultLimits()
        {
            var score = 10m;
            var list = new List<Level>() { lowLevel, mediumLevel, highLevel, defaultLevel };

            var result = _service.CalculateLevel(score, list);

            Assert.Equal(defaultLevel.Id, result);
        }

        [Fact]
        public void GetAllInterpretationTranslationsByLevelAndDysfunction_ShouldReturnInterpretationTranslations_WhenValidIds()
        {
            var teamscan = new Teamscan
            {
                Id = teamscanId,
                Number = teamscanNumber,
                Title = $"Teamscan {teamscanNumber}",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today,
                TeamId = teamId,
                ScoreTrust = 3m,
                ScoreAccountability = 2m,
                ScoreCommitment = 4m,
                ScoreConflict = 2.5m,
                ScoreResults = 5m,
                StartedById = startedById
            };

            var levels = new List<Level>() { lowLevel, mediumLevel, highLevel, defaultLevel };

            var trustInterpretation = new InterpretationTranslation 
            {
                InterpretationId = trustInterpretationId,
                LanguageId = languageId,
                Text = text            
            };

            var conflictInterpretation = new InterpretationTranslation
            {
                InterpretationId = conflictInterpretationId,
                LanguageId = languageId,
                Text = text
            };

            var commitmentInterpretation = new InterpretationTranslation
            {
                InterpretationId = commitmentInterpretationId,
                LanguageId = languageId,
                Text = text
            };

            var accountabilityInterpretation = new InterpretationTranslation
            {
                InterpretationId = accountabilityInterpretationId,
                LanguageId = languageId,
                Text = text
            };

            var resultsInterpretation = new InterpretationTranslation
            {
                InterpretationId = resultsInterpretationId,
                LanguageId = languageId,
                Text = text
            };

            _unitOfWork.Setup(x => x.TeamscanRepository.GetById(teamscanId)).Returns(teamscan);
            _unitOfWork.Setup(x => x.DysfunctionRepository.GetAll(It.IsAny<Expression<Func<Dysfunction, bool>>>(), null, It.IsAny<Expression<Func<Dysfunction, object>>[]>())).Returns(dysfunctions);
            _unitOfWork.Setup(x => x.LevelRepository.GetAll(It.IsAny<Expression<Func<Level, bool>>>(), null, It.IsAny<Expression<Func<Level, object>>[]>())).Returns(levels);

            _unitOfWork.Setup(x => x.InterpretationTranslationRepository.GetTranslatedInterpretationTranslationByLevelAndDysfunction(1, 1, languageId)).Returns(trustInterpretation);
            _unitOfWork.Setup(x => x.InterpretationTranslationRepository.GetTranslatedInterpretationTranslationByLevelAndDysfunction(1, 2, languageId)).Returns(conflictInterpretation);
            _unitOfWork.Setup(x => x.InterpretationTranslationRepository.GetTranslatedInterpretationTranslationByLevelAndDysfunction(3, 3, languageId)).Returns(commitmentInterpretation);
            _unitOfWork.Setup(x => x.InterpretationTranslationRepository.GetTranslatedInterpretationTranslationByLevelAndDysfunction(1, 4, languageId)).Returns(accountabilityInterpretation);
            _unitOfWork.Setup(x => x.InterpretationTranslationRepository.GetTranslatedInterpretationTranslationByLevelAndDysfunction(3, 5, languageId)).Returns(resultsInterpretation);

            var result = _service.GetAllInterpretationTranslationsByLevelAndDysfunction(languageId, teamscanId);

            Assert.Equal(5, result.ToList().Count);
        }
    }
}
