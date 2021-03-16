using AutoMapper;
using Common.DTOs.UserDTO;
using DAL.Repositories;
using DAL.Repositories.UserRepositories;
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

        public Task<UserReadDto> GetUser(string email, string password)
        {
            return _mapper.Map<Task<UserReadDto>>(_unitOfWork.UserRepository.GetUser(email, password));
        }
    }
}
