using AutoMapper;
using DAL.Data;
using DAL.Repositories.IndividualScoreRepositories;
using DAL.Repositories.TeamRepositories;
using DAL.Repositories.TeamscanRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineTeamScanContext _context;
        private readonly IMapper _mapper;
        private IIndividualScoreRepository _individualScoreRepository;
        private ITeamRepository _teamRepository;
        private ITeamscanRepository _teamscanRepository;

        public UnitOfWork(OnlineTeamScanContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IIndividualScoreRepository IndividualScoreRepository
        {
            get { return _individualScoreRepository ??= new IndividualScoreRepository(_context, _mapper); }
        }

        public ITeamRepository TeamRepository
        {
            get { return _teamRepository ??= new TeamRepository(_context, _mapper); }
        }

        public ITeamscanRepository TeamscanRepository
        {
            get { return _teamscanRepository ??= new TeamscanRepository(_context, _mapper); }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
