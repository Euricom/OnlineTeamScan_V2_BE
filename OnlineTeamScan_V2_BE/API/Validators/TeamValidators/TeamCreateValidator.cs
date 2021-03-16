using Common.DTOs.TeamDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validators.TeamValidators
{
    public class TeamCreateValidator : AbstractValidator<TeamCreateDto>
    {
        public TeamCreateValidator()
        {
            
        }
    }
}
