using AutoMapper;
using Common.DTOs.AnswerDTO;
using Common.DTOs.IndividualScoreDTO;
using Common.DTOs.TeamscanDTO;
using DAL.Models;
using DAL.Repositories;
using DAL.Repositories.IndividualScoreRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.IndividualScoreServices
{
    public class IndividualScoreService : IIndividualScoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IndividualScoreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IndividualScoreReadDto GetIndividualScoreById(int id)
        {
            return _mapper.Map<IndividualScoreReadDto>(_unitOfWork.IndividualScoreRepository.GetById(id));
        }

        public IEnumerable<IndividualScoreReadDto> GetAllIndividualScores()
        {
            return _mapper.Map<IEnumerable<IndividualScoreReadDto>>(_unitOfWork.IndividualScoreRepository.GetAll());
        }

        public void CalculateTeamscore(int teamscanId)
        {
            var individualScores = _unitOfWork.IndividualScoreRepository.GetAllByTeamscan(teamscanId);
            int totalScores = individualScores.Count();
            decimal sumTrust = 0, sumConflict = 0, sumCommitment = 0, sumAccountability = 0, sumResults = 0;

            individualScores.ToList().ForEach(i => sumTrust += i.ScoreTrust);
            individualScores.ToList().ForEach(i => sumConflict += i.ScoreConflict);
            individualScores.ToList().ForEach(i => sumCommitment += i.ScoreCommitment);
            individualScores.ToList().ForEach(i => sumAccountability += i.ScoreAccountability);
            individualScores.ToList().ForEach(i => sumResults += i.ScoreResults);

            TeamscanUpdateDto teamscanUpdateDto = new TeamscanUpdateDto
            {
                Id = teamscanId,
                ScoreTrust = Math.Round(sumTrust / totalScores, 2),
                ScoreConflict = Math.Round(sumConflict / totalScores, 2),
                ScoreCommitment = Math.Round(sumCommitment / totalScores, 2),
                ScoreAccountability = Math.Round(sumAccountability / totalScores, 2),
                ScoreResults = Math.Round(sumResults / totalScores, 2)
            };

            _unitOfWork.TeamscanRepository.UpdateScores(_mapper.Map<Teamscan>(teamscanUpdateDto));
            _unitOfWork.Commit();
        }
    }
}
