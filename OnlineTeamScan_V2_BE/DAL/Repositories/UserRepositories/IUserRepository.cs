using Common.DTOs.UserDTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.UserRepositories
{
    public interface IUserRepository : IGenericRepository<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        public Task<UserReadDto> GetUser(string email, string password);
    }
}
