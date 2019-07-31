using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tsmp.User.Domain;

namespace Tsmp.User.Infrastructure.ConcreteRepository
{
    public class PasswordResetRepository : IPasswordResetRepository
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMongoCollection<PasswordResetEntity> _mongoCollection;

        public PasswordResetRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
            _mongoCollection = _mongoDatabase.GetCollection<PasswordResetEntity>("PasswordReset");

        }

        public Task CreatePasswordResetAsync(PasswordResetEntity passwordResetEntity, CancellationToken cancellationToken = default)
        {
            return _mongoCollection.InsertOneAsync(passwordResetEntity, cancellationToken: cancellationToken);
        }
    }
}
