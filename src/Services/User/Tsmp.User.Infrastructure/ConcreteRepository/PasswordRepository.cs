using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Tsmp.User.Domain;

namespace Tsmp.User.Infrastructure
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly IMongoDatabase _mongoDatabsae;
        private readonly IMongoCollection<PasswordEntity> _mongoCollection;

        public PasswordRepository(IMongoDatabase mongoDatabsae)
        {
            _mongoDatabsae = mongoDatabsae;
            _mongoCollection = _mongoDatabsae.GetCollection<PasswordEntity>("Password");
        }

        public Task CreatePasswordAsync(PasswordEntity passwordEntity, CancellationToken cancellationToken = default)
        {
            return _mongoCollection.InsertOneAsync(passwordEntity, cancellationToken: cancellationToken);
        }
    }
}
