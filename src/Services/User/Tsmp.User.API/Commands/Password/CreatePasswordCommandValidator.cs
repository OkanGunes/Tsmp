using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tsmp.User.API.Commands
{
    public class CreatePasswordCommandValidator : AbstractValidator<CreatePasswordCommand>
    {
        public CreatePasswordCommandValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(7, 25);

            RuleFor(x => x.UserId)
                .NotEmpty();
        }
    }
}
