using FluentValidation;
using sage.challenge.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sage.challenge.api.Validators
{
    public class UserValidator : AbstractValidator<UserRequestModel>
    {
        public UserValidator()
        {
            RuleFor(m => m.FirstName).NotEmpty().MaximumLength(128);
            RuleFor(m => m.LastName).MaximumLength(128);
            RuleFor(m => m.Email).NotEmpty().EmailAddress();
        }
    }
}
