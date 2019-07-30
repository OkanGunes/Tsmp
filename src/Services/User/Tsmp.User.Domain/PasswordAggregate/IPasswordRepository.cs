using System.Threading;
using System.Threading.Tasks;

namespace Tsmp.User.Domain
{
    public interface IPasswordRepository
    {
        Task CreatePasswordAsync(PasswordEntity passwordEntity, CancellationToken cancellationToken = default);
    }
}
