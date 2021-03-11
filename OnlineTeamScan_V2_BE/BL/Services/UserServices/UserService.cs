using Common.DTOs.UserDTO;
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
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UserReadDto> GetAllUsers()
        {
            return _repository.GetAll();
        }

        public Task<UserReadDto> GetUser(string email, string password)
        {
            return _repository.GetUser(email, password);
        }
    }
}
