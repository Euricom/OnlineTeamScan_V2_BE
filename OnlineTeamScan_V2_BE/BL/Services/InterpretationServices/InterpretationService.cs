using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.InterpretationServices
{
    public class InterpretationService : IInterpretationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InterpretationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
