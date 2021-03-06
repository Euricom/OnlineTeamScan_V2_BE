﻿using DAL.Repositories.DysfunctionRepositories;
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
    public interface IUnitOfWork
    {
        public IIndividualScoreRepository IndividualScoreRepository { get; }
        public ITeamRepository TeamRepository { get; }
        public ITeamscanRepository TeamscanRepository { get; }
        public IUserRepository UserRepository { get; }
        public ILevelRepository LevelRepository { get; }
        public IDysfunctionRepository DysfunctionRepository { get; }
        public IDysfunctionTranslationRepository DysfunctionTranslationRepository { get; }
        public IInterpretationTranslationRepository InterpretationTranslationRepository { get; }
        public IInterpretationRepository InterpretationRepository { get; }
        public ITeamMemberRepository TeamMemberRepository { get; }
        public IQuestionTranslationRepository QuestionTranslationRepository { get; }
        public IRecommendationTranslationRepository RecommendationTranslationRepository { get; }
        public void Commit();

        public void Rollback();
    }
}
