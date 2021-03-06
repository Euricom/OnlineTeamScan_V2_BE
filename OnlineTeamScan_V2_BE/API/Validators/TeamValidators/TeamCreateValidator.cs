﻿using Common.DTOs.TeamDTO;
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
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(50).WithMessage("{PropertyName} is too long");

            RuleFor(x => x.TeamleaderId)
                .NotNull().WithMessage("{PropertyName} cannot be empty")
                .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} cannot be less than 0");
        }
    }
}
