using Common.DTOs.UserDTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.UserRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> GetUser(string email, string password);
    }
}
