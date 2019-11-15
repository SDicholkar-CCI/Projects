using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using ScratchCardApp.DAL;
using ScratchCardApp.Mapping;
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
            builder.RegisterType<UserServices>().As<IUser>().InstancePerRequest();
            builder.RegisterType<ScratchCardServices>().As<IScratchCard>().InstancePerRequest();
            builder.RegisterType<TransactionServices>().As<ITransaction>().InstancePerRequest();
            builder.RegisterType<ScratchCardContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<UserRespository>().AsSelf().InstancePerRequest();
            builder.RegisterType<ScratchCardRepository>().AsSelf().InstancePerRequest();
            builder.RegisterType<TransactionRespository>().AsSelf().InstancePerRequest();
            builder.RegisterType<MapperProfile>().AsSelf().InstancePerRequest();
            var container = builder.Build();
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}