using AutoMapper;
using Common.DTOs.UserDTO;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.UserRepositories
{
    public class UserRepository : GenericRepository<User, UserReadDto, UserCreateDto, UserUpdateDto>, IUserRepository
    {
        public UserRepository(OnlineTeamScanContext context, IMapper mapper) : base(context, mapper)
        { }

        public async Task<UserReadDto> GetUser(string email, string password)
        {
            return _mapper.Map<UserReadDto>(await _dbSet.FirstOrDefaultAsync(u => u.Email == email && u.Password == password));
        }
    }
}
