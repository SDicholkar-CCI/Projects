using Autofac;
using Autofac.Integration.WebApi;
using ScratchCardApp.DAL;
using ScratchCardApp.Respository;
using ScratchCardApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace ScratchCardApp.App_Start
{
    public class AutoFacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ScratchCardServices>().As<IScratchCard>().InstancePerRequest();
            builder.RegisterType<ScratchCardContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<ScratchCardRespository>().AsSelf().InstancePerRequest();
            var container = builder.Build();
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}