using Infrastructure.Core;
using System.Collections.Generic;

namespace Infrastructure.Data.Model {
    public class Comment : Entity {
        public Comment() {
            Children = new List<Comment>();
        }
        public string Author { get; set; }
        public string Content { get; set; }
        public List<Comment> Children { get; set; }

        public int PageId { get; set; }
        public Page Page { get; set; }

    }
}
