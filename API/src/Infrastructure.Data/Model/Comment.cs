using Infrastructure.Core;
using System.Collections.Generic;

namespace Infrastructure.Data.Model {
    public class Comment : Entity {
        public string Author { get; set; }
        public string Content { get; set; }
        public ICollection<Comment> Children { get; set; }

        public int PageId { get; set; }
        public Page Page { get; set; }

    }
}
