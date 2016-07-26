using Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Model
{
    public class Page : AggregateRoot {
        public Page() {
            Comments = new HashSet<Comment>();
        }
        public string Name { get; set; }
        public virtual ICollection<Comment> Comments {get;set;}
    }
}
