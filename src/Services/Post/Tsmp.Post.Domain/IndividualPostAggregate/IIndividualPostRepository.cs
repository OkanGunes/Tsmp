using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tsmp.Post.Domain
{
    public interface IIndividualPostRepository
    {
        Task CreatePostAsync(IndividualPostEntity postEntity);
    }
}
