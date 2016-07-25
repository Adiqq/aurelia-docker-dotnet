using Autofac;
using Infrastructure.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Core.IoC
{
    public class AutofacDependencyResolver : IDependencyResolver {
        private readonly IComponentContext _context;
        public AutofacDependencyResolver(IComponentContext context) {
            _context = context;
        }
        public T Resolve<T>() {
            return _context.Resolve<T>();
        }
    }
}
