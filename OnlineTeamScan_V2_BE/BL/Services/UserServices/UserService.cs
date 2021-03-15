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

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UserReadDto> GetAllUsers()
        {
            return _unitOfWork.UserRepository.GetAll();
        }

        public Task<UserReadDto> GetUser(string email, string password)
        {
            return _unitOfWork.UserRepository.GetUser(email, password);
        }
    }
}
