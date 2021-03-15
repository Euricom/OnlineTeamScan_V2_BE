using AutoMapper;
using Common.DTOs.IndividualScoreDTO;
using Common.DTOs.TeamscanDTO;
using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.TeamscanRepositories
{
    public class TeamscanRepository : GenericRepository<Teamscan, TeamscanReadDto, object, object>, ITeamscanRepository
    {
        public TeamscanRepository(OnlineTeamScanContext context, IMapper mapper) : base(context, mapper)
        { }

        public TeamscanReadDto UpdateScores(TeamscanUpdateDto teamscanUpdateDto)
        {
            var entry = _context.Entry(_mapper.Map<Teamscan>(teamscanUpdateDto));
            entry.Property(x => x.ScoreTrust).IsModified = true;
            entry.Property(x => x.ScoreConflict).IsModified = true;
            entry.Property(x => x.ScoreCommitment).IsModified = true;
            entry.Property(x => x.ScoreAccountability).IsModified = true;
            entry.Property(x => x.ScoreResults).IsModified = true;

            return _mapper.Map<TeamscanReadDto>(entry.Entity);
        }
    }
}
