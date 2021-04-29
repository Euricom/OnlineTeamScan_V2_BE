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

        public InterpretationTranslationServiceTests()
        {
            _service = new InterpretationTranslationService(_unitOfWork.Object, _mapper);
        }
    }
}
