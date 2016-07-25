using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Application.CommandHandlers;
using Infrastructure.Core;
using Application.Commands;
using Application.QueryHandlers;
using Application.Queries;
using Infrastructure.Data.Model;

namespace Application.IoC {
    public class Module : Autofac.Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<CreateCommentCommandHandler>().As<ICommandHandler<CreateCommentCommand>>();
            builder.RegisterType<CreatePageCommandHandler>().As<ICommandHandler<CreatePageCommand>>();

            builder.RegisterType<GetPageByNameQueryHandler>().As<IQueryHandler<GetPageByNameQuery, Page>>();
        }
    }
}
