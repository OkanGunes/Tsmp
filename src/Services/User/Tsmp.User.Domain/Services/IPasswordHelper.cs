namespace Tsmp.User.Domain.Services
{
    public interface IPasswordHelper
    {
        string ComputeHash(string password);

        bool CompareHash(string hash, string password);
    }
}
