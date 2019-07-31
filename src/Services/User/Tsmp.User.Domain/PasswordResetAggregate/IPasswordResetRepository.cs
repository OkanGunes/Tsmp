using System.Threading;
using System.Threading.Tasks;

namespace Tsmp.User.Domain
{
    public interface IPasswordResetRepository
    {
        Task CreatePasswordResetAsync(PasswordResetEntity passwordResetEntity, CancellationToken cancellationToken = default);
    }
}
