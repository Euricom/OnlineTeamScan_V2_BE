using AutoMapper;
using Common.DTOs.TeamMemberDTO;
using DAL.Models;
using DAL.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.TeamMemberServices
{
    public class TeamMemberService : ITeamMemberService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeamMemberService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public TeamMemberReadDto GetTeamMemberById(int id)
        {
            var teamMember = _unitOfWork.TeamMemberRepository.GetById(id);

            if (teamMember == null)
                return null;

            return _mapper.Map<TeamMemberReadDto>(teamMember);
        }

        public IEnumerable<TeamMemberReadDto> GetAllTeamMembersByTeam(int teamId)
        {
            return _mapper.Map<IEnumerable<TeamMemberReadDto>>(_unitOfWork.TeamMemberRepository.GetAllTeamMembersByTeam(teamId));
        }

        public TeamMemberReadDto AddTeamMember(TeamMemberCreateDto teamMemberCreateDto)
        {
            try
            {
                var newTeamMember = _unitOfWork.TeamMemberRepository.Add(_mapper.Map<TeamMember>(teamMemberCreateDto));
                _unitOfWork.Commit();
                return _mapper.Map<TeamMemberReadDto>(newTeamMember);
            }
            catch (DbUpdateException ex) when ((ex.InnerException as SqlException)?.Number == 2601)
            {
                _unitOfWork.Rollback();
                throw new Exception($"Teammember already exists with the email {teamMemberCreateDto.Email}", ex);
            }           
        }

        public TeamMemberReadDto UpdateTeamMember(TeamMemberUpdateDto teamMemberUpdateDto)
        {
            try
            {
                var updatedTeamMember = _unitOfWork.TeamMemberRepository.UpdateTeamMember(_mapper.Map<TeamMember>(teamMemberUpdateDto));
                _unitOfWork.Commit();
                return _mapper.Map<TeamMemberReadDto>(updatedTeamMember);
            }
            catch (DbUpdateException ex) when ((ex.InnerException as SqlException)?.Number == 2601)
            {
                _unitOfWork.Rollback();
                throw new Exception($"Teammember already exists with the email {teamMemberUpdateDto.Email}", ex);
            }
        }

        public void DeleteTeamMember(int id)
        {
            _unitOfWork.TeamMemberRepository.Delete(id);
            _unitOfWork.Commit();
        }
    }
}
