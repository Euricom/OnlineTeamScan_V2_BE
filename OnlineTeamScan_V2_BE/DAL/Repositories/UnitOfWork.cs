using DAL.Data;
using DAL.Repositories.IndividualScoreRepositories;
using DAL.Repositories.TeamRepositories;
using DAL.Repositories.TeamscanRepositories;
using DAL.Repositories.UserRepositories;
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
        private IUserRepository _userRepository;

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

        public IUserRepository UserRepository
        {
            get { return _userRepository ??= new UserRepository(_context); }
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
