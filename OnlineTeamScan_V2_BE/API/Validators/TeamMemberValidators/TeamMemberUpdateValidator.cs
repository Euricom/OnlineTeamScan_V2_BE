using Common.DTOs.TeamMemberDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validators.TeamMemberValidators
{
    public class TeamMemberUpdateValidator : AbstractValidator<TeamMemberUpdateDto>
    {
        public TeamMemberUpdateValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(100).WithMessage("{PropertyName} is too long")
                .EmailAddress().WithMessage("Please specify a valid {PropertyName}");

            RuleFor(x => x.Firstname)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(70).WithMessage("{PropertyName} is too long");

            RuleFor(x => x.Lastname)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(70).WithMessage("{PropertyName} is too long");

            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("{PropertyName} cannot be empty")
               .Must(x => x == false || x == true).WithMessage("{PropertyName} must be true or false");
        }
    }
}
