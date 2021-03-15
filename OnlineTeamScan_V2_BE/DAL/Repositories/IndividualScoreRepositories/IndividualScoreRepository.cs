using AutoMapper;
using Common.DTOs.AnswerDTO;
using Common.DTOs.IndividualScoreDTO;
using Common.DTOs.TeamscanDTO;
using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.IndividualScoreRepositories
{
    public class IndividualScoreRepository : GenericRepository<IndividualScore, IndividualScoreReadDto, IndividualScoreCreateDto, object>, IIndividualScoreRepository
    {
        public IndividualScoreRepository(OnlineTeamScanContext context, IMapper mapper) : base(context, mapper)
        { }

        public IEnumerable<IndividualScoreReadDto> GetAllByTeamscan(int teamscanId)
        {
            return _mapper.Map<IEnumerable<IndividualScoreReadDto>> (_dbSet.Where(i => i.TeamscanId == teamscanId).ToList());
        }
    }
}
