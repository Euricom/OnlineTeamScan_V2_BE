using AutoMapper;
using Common.DTOs.TeamDTO;
using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.TeamRepositories
{
    public class TeamRepository : GenericRepository<Team, TeamReadDto, TeamCreateDto, TeamUpdateDto>, ITeamRepository
    {
        public TeamRepository(OnlineTeamScanContext context, IMapper mapper) : base(context, mapper)
        { }
    }
}
