using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tsmp.User.Domain;
using Tsmp.User.Domain.Services;

namespace Tsmp.User.API.Commands
{
    public class CreatePasswordCommandHandler : IRequestHandler<CreatePasswordCommand, string>
    {
        private readonly IPasswordRepository _passwordRepository;
        private readonly IPasswordHelper _passwordHelper;

        public CreatePasswordCommandHandler(IPasswordRepository passwordRepository, IPasswordHelper passwordHelper)
        {
            _passwordRepository = passwordRepository;
            _passwordHelper = passwordHelper;
        }

        public async Task<string> Handle(CreatePasswordCommand request, CancellationToken cancellationToken)
        {
            var passwordEntity = new PasswordEntity
            {
                Id = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.UtcNow,
                Hash = _passwordHelper.ComputeHash(request.Password),
                UserId = request.UserId
            };

            await _passwordRepository.CreatePassword(passwordEntity);

            return passwordEntity.Id;
        }
    }
}
