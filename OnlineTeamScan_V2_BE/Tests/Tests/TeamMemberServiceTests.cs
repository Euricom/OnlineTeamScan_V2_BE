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

        private readonly int id = 1;
        private readonly string email = "john.smith@gmail.com";
        private readonly string firstname = "John";
        private readonly string lastname = "Smith";
        private readonly bool isActive = true;
        private readonly int teamId = 1;

        public TeamMemberServiceTests()
        {
            _service = new TeamMemberService(_unitOfWork.Object, _mapper);
        }

        [Fact]
        public void GetTeamMemberById_ShouldReturnTeamMember_WhenTeamMemberExists()
        {
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

            var result = _service.GetTeamMemberById(id);

            Assert.Equal(id, result.Id);
            Assert.Equal(email, result.Email);
            Assert.Equal(firstname, result.Firstname);
            Assert.Equal(lastname, result.Lastname);
            Assert.Equal(isActive, result.IsActive);
        }

        [Fact]
        public void GetTeamMemberById_ShouldReturnNull_WhenTeamMemberDoesNotExists()
        {
            _unitOfWork.Setup(x => x.TeamMemberRepository.GetById(It.IsAny<int>())).Returns(() => null);

            var result = _service.GetTeamMemberById(1);

            Assert.Null(result);
        }

        [Fact]
        public void AddTeamMember_ShouldAddTeamMember_WhenValidTeamMember()
        {         
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

            var result = _service.AddTeamMember(teamMemberCreateDto);

            Assert.Equal(id, result.Id);
            Assert.Equal(email, result.Email);
            Assert.Equal(firstname, result.Firstname);
            Assert.Equal(lastname, result.Lastname);
            Assert.Equal(isActive, result.IsActive);
        }

        [Fact]
        public void AddTeamMember_ShouldThrowException_WhenDuplicateTeamMember()
        {           
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

            var result = Record.Exception(() => _service.AddTeamMember(teamMemberCreateDto));

            Assert.IsType<DbUpdateException>(result);
        }

        [Fact]
        public void UpdateTeamMember_ShouldUpdateTeamMember_WhenValidTeamMember()
        {           
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

            var result = _service.UpdateTeamMember(teamMemberUpdateDto);

            Assert.Equal(id, result.Id);
            Assert.Equal(email, result.Email);
            Assert.Equal(firstname, result.Firstname);
            Assert.Equal(lastname, result.Lastname);
            Assert.Equal(isActive, result.IsActive);
        }

        [Fact]
        public void UpdateTeamMember_ShouldThrowException_WhenDuplicateTeamMember()
        {          
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

            var result = Record.Exception(() => _service.UpdateTeamMember(teamMemberUpdateDto));

            Assert.IsType<DbUpdateException>(result);
        }
    }
}
