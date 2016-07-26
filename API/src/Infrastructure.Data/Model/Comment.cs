﻿using Infrastructure.Core;
using System.Collections.Generic;

namespace Infrastructure.Data.Model {
    public class Comment : Entity
    {
        public Comment() {
            Children = new HashSet<Comment>();
        }
        public string Author { get; set; }
        public string Content { get; set; }
        public virtual ICollection<Comment> Children { get; set; }
    }
}
