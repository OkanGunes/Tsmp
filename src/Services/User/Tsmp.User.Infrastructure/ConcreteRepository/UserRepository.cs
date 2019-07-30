using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading;
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

        public Task<bool> AnyAsync(Expression<Func<UserEntity, bool>> exp, CancellationToken cancellationToken = default)
        {
            return _mongoCollection.Find(exp).AnyAsync(cancellationToken: cancellationToken);
        }

        public Task CreateUserAsync(UserEntity userEntity, CancellationToken cancellationToken = default)
        {
            return _mongoCollection.InsertOneAsync(userEntity, cancellationToken: cancellationToken);
        }
    }
}
