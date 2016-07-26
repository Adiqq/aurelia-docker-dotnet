using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Infrastructure.Core.IoC;
using Infrastructure.Core.Interfaces;

namespace Infrastructure.Core.IoC
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();
            builder.RegisterType<AutofacDependencyResolver>().As<IDependencyResolver>();
        }
    }
}
