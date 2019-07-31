using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsmp.User.Domain;

namespace Tsmp.User.API.Commands
{
    public class CreatePasswordResetCommandValidator : AbstractValidator<CreatePasswordResetCommand>
    {
        public CreatePasswordResetCommandValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.Email)
               .NotEmpty()
               .EmailAddress()
               .DependentRules(() =>
               {
                   RuleFor(x => x.Email).CustomAsync(async (email, context, cancellationToken) =>
                   {
                       var isExist = await userRepository.AnyAsync(x => x.Email.ToLowerInvariant() == email.ToLowerInvariant(), cancellationToken);

                       if (!isExist)
                       {
                           context.AddFailure(nameof(CreatePasswordResetCommand.Email), "Email not found");
                       }
                   });
               });
        }
    }
}
