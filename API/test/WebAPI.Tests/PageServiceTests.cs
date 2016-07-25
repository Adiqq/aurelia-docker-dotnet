using Autofac;
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

            var container = builder.Build();

            var service = container.Resolve<IPageService>();
        }
    }
}
