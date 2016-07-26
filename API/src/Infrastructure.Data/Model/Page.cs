using Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Model
{
    public class Page : AggregateRoot {
        public string Name { get; set; }
        public List<Comment> Comments {get;set;}
    }
}
