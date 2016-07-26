using Application.CommandHandlers;
using Autofac;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services;
using Xunit;

namespace WebAPI.Tests
{
    public class PageServiceTests
    {
        [Fact]
        public void ResolveService() {
            var builder = new ContainerBuilder();
            builder.RegisterModule<Application.IoC.Module>();
            builder.RegisterModule<Infrastructure.Core.IoC.Module>();

            builder.RegisterType<PageService>().As<IPageService>();

            var mock = new Mock<ILogger<PageService>>();
            var mock2 = new Mock<ILogger<CreateCommentCommandHandler>>();
            builder.RegisterInstance(mock.Object).As<ILogger<PageService>>();
            builder.RegisterInstance(mock2.Object).As<ILogger<CreateCommentCommandHandler>>();

            var container = builder.Build();

          

            var service = container.Resolve<IPageService>();
        }
    }
}
