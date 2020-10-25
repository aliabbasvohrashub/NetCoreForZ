using FluentValidation;
using sage.challenge.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sage.challenge.api.Validators
{
    public class AccountValidator : AbstractValidator<AccountRequestModel>
    {
        public AccountValidator()
        {
            RuleFor(m => m.CompanyName).NotEmpty().MaximumLength(128);
            RuleFor(m => m.Website);
        }
    }
}
