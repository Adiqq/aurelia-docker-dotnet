using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Core
{
    public interface ICommandDispatcher {
        void Execute<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}
