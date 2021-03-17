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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(OnlineTeamScanContext context) : base(context)
        { }

    }
}
