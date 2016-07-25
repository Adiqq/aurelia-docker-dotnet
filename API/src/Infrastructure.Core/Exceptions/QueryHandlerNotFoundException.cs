using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Core.Exceptions
{
    public class QueryHandlerNotFoundException : Exception {
        public Type Type { get; }

        public QueryHandlerNotFoundException(Type type) {
            Type = type;
        }
    }
}
