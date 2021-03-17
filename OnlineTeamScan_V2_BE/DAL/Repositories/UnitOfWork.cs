using DAL.Data;
using DAL.Repositories.DysfunctionTranslationRepositories;
using DAL.Repositories.IndividualScoreRepositories;
using DAL.Repositories.LevelRepositories;
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
        private IIndividualScoreRepository _individualScoreRepository;
        private ITeamRepository _teamRepository;
        private ITeamscanRepository _teamscanRepository;
        private ILevelRepository _levelRepository;
        private IDysfunctionTranslationRepository _dysfunctionTranslationRepository;

        public UnitOfWork(OnlineTeamScanContext context)
        {
            _context = context;
        }

        public IIndividualScoreRepository IndividualScoreRepository
        {
            get { return _individualScoreRepository ??= new IndividualScoreRepository(_context); }
        }

        public ITeamRepository TeamRepository
        {
            get { return _teamRepository ??= new TeamRepository(_context); }
        }

        public ITeamscanRepository TeamscanRepository
        {
            get { return _teamscanRepository ??= new TeamscanRepository(_context); }
        }

        public ILevelRepository LevelRepository
        {
            get { return _levelRepository ??= new LevelRepository(_context); }
        }

        public IDysfunctionTranslationRepository DysfunctionTranslationRepository
        {
            get { return _dysfunctionTranslationRepository ??= new DysfunctionTranslationRepository(_context); }
        }

        public void Commit()
        {
            _context.SaveChanges();          
        }

        public void Rollback()
        {
            _context.Dispose();
        }
    }
}
