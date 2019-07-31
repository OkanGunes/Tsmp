using System;
using System.Collections.Generic;
using System.Text;

namespace Tsmp.Post.Domain
{
    public class IndividualPostEntity
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public PostType PostType => PostType.Individual;
    }
}
