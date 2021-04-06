using AutoMapper;
using BL.Services.TeamMemberServices;
using Common.DTOs.TeamMemberDTO;
using DAL.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using Xunit;

namespace Tests.Tests
{
    public class TeamMemberServiceTests
    {
        private readonly TeamMemberService _service;
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();
        private readonly IMapper _mapper = MapperConfig.Initialize();

        private int id = 1;
        private string email = "john.smith@gmail.com";
        private string firstname = "John";
        private string lastname = "Smith";
        private bool isActive = true;
        private int teamId = 1;

        public TeamMemberServiceTests()
        {
            _service = new TeamMemberService(_unitOfWork.Object, _mapper);
        }

        [Fact]
        public void GetTeamMemberById_ShouldReturnTeamMember_WhenTeamMemberExists()
        {
            // Arrange
            var teamMember = new TeamMember
            {
                Id = id,
                Email = email,
                Firstname = firstname,
                Lastname = lastname,
                IsActive = isActive,
                TeamId = teamId
            };          

            _unitOfWork.Setup(x => x.TeamMemberRepository.GetById(id)).Returns(teamMember);

            // Act
            var result = _service.GetTeamMemberById(id);

            // Assert
            Assert.Equal(id, result.Id);
            Assert.Equal(email, result.Email);
            Assert.Equal(firstname, result.Firstname);
            Assert.Equal(lastname, result.Lastname);
            Assert.Equal(isActive, result.IsActive);
        }

        [Fact]
        public void GetTeamMemberById_ShouldReturnNull_WhenTeamMemberDoesNotExists()
        {
            // Arrange
            _unitOfWork.Setup(x => x.TeamMemberRepository.GetById(It.IsAny<int>())).Returns(() => null);

            // Act
            var result = _service.GetTeamMemberById(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void AddTeamMember_ShouldAddTeamMember_WhenValidTeamMember()
        {
            // Arrange            
            var teamMemberCreateDto = new TeamMemberCreateDto
            {
                TeamId = teamId,
                Email = email,
                Firstname = firstname,
                Lastname = lastname
            };

            var newTeamMember = new TeamMember
            {
                Id = id,
                Email = teamMemberCreateDto.Email,
                Firstname = teamMemberCreateDto.Firstname,
                Lastname = teamMemberCreateDto.Lastname,
                IsActive = isActive,
                TeamId = teamId
            };
           
            _unitOfWork.Setup(x => x.TeamMemberRepository.Add(It.Is<TeamMember>(x => x.Email == teamMemberCreateDto.Email 
            && x.Firstname == teamMemberCreateDto.Firstname 
            && x.Lastname == teamMemberCreateDto.Lastname
            && x.TeamId == teamMemberCreateDto.TeamId)))
                .Returns(newTeamMember);           

            // Act
            var result = _service.AddTeamMember(teamMemberCreateDto);

            // Assert
            Assert.Equal(id, result.Id);
            Assert.Equal(email, result.Email);
            Assert.Equal(firstname, result.Firstname);
            Assert.Equal(lastname, result.Lastname);
            Assert.Equal(isActive, result.IsActive);
        }

        [Fact]
        public void AddTeamMember_ShouldThrowException_WhenDuplicateTeamMember()
        {
            // Arrange            
            var teamMemberCreateDto = new TeamMemberCreateDto
            {
                TeamId = teamId,
                Email = email,
                Firstname = firstname,
                Lastname = lastname
            };

            var newTeamMember = new TeamMember
            {
                Id = id,
                Email = teamMemberCreateDto.Email,
                Firstname = teamMemberCreateDto.Firstname,
                Lastname = teamMemberCreateDto.Lastname,
                IsActive = isActive,
                TeamId = teamId
            };

            _unitOfWork.Setup(x => x.TeamMemberRepository.Add(It.IsAny<TeamMember>())).Returns(newTeamMember);
            _unitOfWork.Setup(x => x.Commit()).Throws(new DbUpdateException());

            // Act
            var result = Record.Exception(() => _service.AddTeamMember(teamMemberCreateDto));

            // Assert
            Assert.IsType<DbUpdateException>(result);
        }

        [Fact]
        public void UpdateTeamMember_ShouldUpdateTeamMember_WhenValidTeamMember()
        {
            // Arrange            
            var teamMemberUpdateDto = new TeamMemberUpdateDto
            {
                Id = id,
                Email = email,
                Firstname = firstname,
                Lastname = lastname,
                IsActive = isActive
            };

            var updatedTeamMember = new TeamMember
            {
                Id = id,
                Email = teamMemberUpdateDto.Email,
                Firstname = teamMemberUpdateDto.Firstname,
                Lastname = teamMemberUpdateDto.Lastname,
                IsActive = isActive,
                TeamId = teamId
            };
           
            _unitOfWork.Setup(x => x.TeamMemberRepository.UpdateTeamMember(It.Is<TeamMember>(x => x.Email == teamMemberUpdateDto.Email 
            && x.Firstname == teamMemberUpdateDto.Firstname 
            && x.Lastname == teamMemberUpdateDto.Lastname
            && x.Id == teamMemberUpdateDto.Id
            && x.IsActive == teamMemberUpdateDto.IsActive)))
                .Returns(updatedTeamMember);           

            // Act
            var result = _service.UpdateTeamMember(teamMemberUpdateDto);

            // Assert
            Assert.Equal(id, result.Id);
            Assert.Equal(email, result.Email);
            Assert.Equal(firstname, result.Firstname);
            Assert.Equal(lastname, result.Lastname);
            Assert.Equal(isActive, result.IsActive);
        }

        [Fact]
        public void UpdateTeamMember_ShouldThrowException_WhenDuplicateTeamMember()
        {
            // Arrange            
            var teamMemberUpdateDto = new TeamMemberUpdateDto
            {
                Id = id,
                Email = email,
                Firstname = firstname,
                Lastname = lastname,
                IsActive = isActive
            };

            var updatedTeamMember = new TeamMember
            {
                Id = id,
                Email = teamMemberUpdateDto.Email,
                Firstname = teamMemberUpdateDto.Firstname,
                Lastname = teamMemberUpdateDto.Lastname,
                IsActive = isActive,
                TeamId = teamId
            };

            _unitOfWork.Setup(x => x.TeamMemberRepository.UpdateTeamMember(It.IsAny<TeamMember>())).Returns(updatedTeamMember);
            _unitOfWork.Setup(x => x.Commit()).Throws(new DbUpdateException());

            // Act
            var result = Record.Exception(() => _service.UpdateTeamMember(teamMemberUpdateDto));

            // Assert
            Assert.IsType<DbUpdateException>(result);
        }
    }
}
