using Infrastructure.Core;
using Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetPageByNameQuery : IQuery<Page>
    {
        public string Name { get;}
        public GetPageByNameQuery(string name) {
            Name = name;
        }
    }
}
