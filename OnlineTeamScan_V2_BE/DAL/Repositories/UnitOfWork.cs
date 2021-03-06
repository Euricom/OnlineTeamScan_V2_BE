﻿using DAL.Data;
using DAL.Repositories.DysfunctionRepositories;
using DAL.Repositories.DysfunctionTranslationRepositories;
using DAL.Repositories.IndividualScoreRepositories;
using DAL.Repositories.InterpretationRepositories;
using DAL.Repositories.InterpretationTranslationRepositories;
using DAL.Repositories.LevelRepositories;
using DAL.Repositories.QuestionTranslationRepositories;
using DAL.Repositories.RecommendationTranslationRepositories;
using DAL.Repositories.TeamMemberRepositories;
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
        private ILevelRepository _levelRepository;
        private IDysfunctionRepository _dysfunctionRepository;
        private IDysfunctionTranslationRepository _dysfunctionTranslationRepository;
        private IInterpretationTranslationRepository _interpretationTranslationRepository;
        private IInterpretationRepository _interpretationRepository;
        private ITeamMemberRepository _teamMemberRepository;
        private IQuestionTranslationRepository _questionTranslationRepository;
        private IRecommendationTranslationRepository _recommendationTranslationRepository;

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

        public IUserRepository UserRepository
        {
            get { return _userRepository ??= new UserRepository(_context); }
        }

        public IInterpretationTranslationRepository InterpretationTranslationRepository
        {
            get { return _interpretationTranslationRepository ??= new InterpretationTranslationRepository(_context); }
        }

        public IInterpretationRepository InterpretationRepository
        {
            get { return _interpretationRepository ??= new InterpretationRepository(_context); }
        }

        public ITeamMemberRepository TeamMemberRepository
        {
            get { return _teamMemberRepository ??= new TeamMemberRepository(_context); }
        }

        public IQuestionTranslationRepository QuestionTranslationRepository
        {
            get { return _questionTranslationRepository ??= new QuestionTranslationRepository(_context); }
        }

        public IRecommendationTranslationRepository RecommendationTranslationRepository
        {
            get { return _recommendationTranslationRepository ??= new RecommendationTranslationRepository(_context); }
        }

        public IDysfunctionRepository DysfunctionRepository
        {
            get { return _dysfunctionRepository ??= new DysfunctionRepository(_context); }
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
