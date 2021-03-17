using Common.DTOs.UserDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validators.UserValidators
{
    public class UserTokenValidator : AbstractValidator<UserTokenDto>
    {
        public UserTokenValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(100);
            RuleFor(x => x.Password).NotEmpty().MaximumLength(70);
        }
    }
}
