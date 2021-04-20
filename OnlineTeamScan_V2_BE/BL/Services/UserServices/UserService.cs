using AutoMapper;
using Common.DTOs.UserDTO;
using DAL.Models;
using DAL.Repositories;
using DAL.Repositories.UserRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<UserReadDto> GetAllUsers()
        {
            return _mapper.Map<IEnumerable<UserReadDto>>(_unitOfWork.UserRepository.GetAll());
        }

        public UserReadDto GetUserByEmail(string email)
        {
            var user = _unitOfWork.UserRepository.GetAll(u => u.Email == email).FirstOrDefault();

            if (user == null)
                return null;

            return _mapper.Map<UserReadDto>(user);
        }

        public UserReadDto GetUserById(int id)
        {
            var user = _unitOfWork.UserRepository.GetById(id);

            if (user == null)
                return null;

            return _mapper.Map<UserReadDto>(user);
        }
    }
}
