using MongoDB.Driver;
using System.Threading.Tasks;
using Tsmp.User.Domain;

namespace Tsmp.User.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _mongoDatabsae;
        private readonly IMongoCollection<UserEntity> _mongoCollection;

        public UserRepository(IMongoDatabase mongoDatabsae)
        {
            _mongoDatabsae = mongoDatabsae;
            _mongoCollection = _mongoDatabsae.GetCollection<UserEntity>("User");
        }

        public Task CreateUser(UserEntity userEntity)
        {
            return _mongoCollection.InsertOneAsync(userEntity);
        }
    }
}
