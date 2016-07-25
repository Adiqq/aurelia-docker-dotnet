using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Core.Exceptions
{
    public class CommandHandlerNotFoundException : Exception {
        public Type Type { get; }

        public CommandHandlerNotFoundException(Type type) {
            Type = type;
        }
    }
}
