using System.Threading.Tasks;

namespace Tsmp.User.Domain
{
    public interface IUserRepository
    {
        Task CreateUser(UserEntity userEntity);
    }
}
