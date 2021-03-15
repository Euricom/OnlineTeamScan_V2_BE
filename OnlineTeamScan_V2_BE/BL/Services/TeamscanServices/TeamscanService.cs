using Common.DTOs.TeamscanDTO;
using DAL.Repositories;
using DAL.Repositories.TeamscanRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.TeamscanServices
{
    public class TeamscanService : ITeamscanService
    {
        /*private readonly ITeamscanRepository _repository;

        public TeamscanService(ITeamscanRepository repository)
        {
            _repository = repository;
        }*/

        private readonly IUnitOfWork _unitOfWOrk;

        public TeamscanService(IUnitOfWork unitOfWork) 
        {
            _unitOfWOrk = unitOfWork;
        }

    }
}
