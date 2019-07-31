using FluentValidation;
using System.Threading.Tasks;
using Tsmp.User.Domain;

namespace Tsmp.User.API.Commands
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .DependentRules(() =>
                {
                    RuleFor(x => x.Email).CustomAsync(async (email, context, cancellationToken) =>
                    {
                        var isExist = await userRepository.AnyAsync(x => x.Email.ToLowerInvariant() == email.ToLowerInvariant(), cancellationToken);

                        if (isExist)
                        {
                            context.AddFailure(nameof(CreateUserCommand.Email), "Email is already registered");
                        }
                    });
                });

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(7, 20);

            RuleFor(x => x.Surname)
                .NotEmpty()
                .MaximumLength(20);
        }
    }
}
