using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Tsmp.User.Domain
{
    public interface IUserRepository
    {
        Task CreateUserAsync(UserEntity userEntity, CancellationToken cancellationToken = default);

        Task<bool> AnyAsync(Expression<Func<UserEntity, bool>> exp, CancellationToken cancellationToken = default);
    }
}
