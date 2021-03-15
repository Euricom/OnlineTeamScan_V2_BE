﻿using DAL.Repositories.IndividualScoreRepositories;
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
    public interface IUnitOfWork
    {
        public IIndividualScoreRepository IndividualScoreRepository { get; }
        public ITeamRepository TeamRepository { get; }
        public ITeamscanRepository TeamscanRepository { get; }
        public IUserRepository UserRepository { get; }
        public void Commit();
    }
}