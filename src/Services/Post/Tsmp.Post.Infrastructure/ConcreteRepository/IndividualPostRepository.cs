using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tsmp.Post.Domain;

namespace Tsmp.Post.Infrastructure
{
    public class IndividualPostRepository : IIndividualPostRepository
    {
        readonly IMongoCollection<IndividualPostEntity> _mongoCollection;
        public IndividualPostRepository(IMongoDatabase mongoDatabase)
        {
            _mongoCollection = mongoDatabase.GetCollection<IndividualPostEntity>("Post");
        }

        public Task CreatePostAsync(IndividualPostEntity postEntity)
        {
            return _mongoCollection.InsertOneAsync(postEntity);
        }
    }
}
