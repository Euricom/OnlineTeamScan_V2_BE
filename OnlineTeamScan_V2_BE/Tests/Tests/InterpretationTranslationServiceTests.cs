using AutoMapper;
using BL.Services.InterpretationTranslationServices;
using Common.DTOs.InterpretationDTO;
using DAL.Models;
using DAL.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private readonly int id = 1;
        private readonly int levelId = 1;
        private readonly int dysfunctionId = 1;
        private readonly int languageId = 1;
        private readonly string text = "This is a test.";

        private readonly Level lowLevel = new Level { Id = 1, LowerLimit = 1m, UpperLimit = 3.24m, Color = "#F95656" };
        private readonly Level mediumLevel = new Level { Id = 2, LowerLimit = 3.25m, UpperLimit = 3.74m, Color = "#FFD54A" };
        private readonly Level highLevel = new Level { Id = 3, LowerLimit = 3.75m, UpperLimit = 5m, Color = "#93EB5F" };
        private readonly Level defaultLevel = new Level { Id = 4, LowerLimit = 0m, UpperLimit = 0m, Color = "#D8D8D8" };    

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
    }
}
