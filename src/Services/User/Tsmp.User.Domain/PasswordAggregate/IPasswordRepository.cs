using System.Threading.Tasks;

namespace Tsmp.User.Domain
{
    public interface IPasswordRepository
    {
        Task CreatePassword(PasswordEntity passwordEntity);
    }
}
