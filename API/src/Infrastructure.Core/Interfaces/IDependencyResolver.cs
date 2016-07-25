using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Core.Interfaces
{
    public interface IDependencyResolver {
        T Resolve<T>();
    }
}
