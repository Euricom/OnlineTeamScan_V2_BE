using Common.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.UserServices
{
    public interface IUserService
    {
        public UserReadDto GetUserById(int id);
        public UserReadDto GetUserByEmail(string email);
        public IEnumerable<UserReadDto> GetAllUsers();
    }
}
