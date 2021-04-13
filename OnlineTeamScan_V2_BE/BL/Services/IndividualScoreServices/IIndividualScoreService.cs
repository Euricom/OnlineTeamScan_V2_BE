using Common.DTOs.AnswerDTO;
using Common.DTOs.IndividualScoreDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.IndividualScoreServices
{
    public interface IIndividualScoreService
    {
        public IndividualScoreReadDto GetIndividualScoreByIdIncludingTeamscan(Guid id);
        public IndividualScoreReadDto GetIndividualScoreById(Guid id);
        public IndividualScoreReadDto UpdateIndividualScore(Guid id, List<AnswerReadDto> list);      
    }
}
