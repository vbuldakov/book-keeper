using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DataAccess;
using DataAccess.Core;
using Services.Users;
using DataAccess.Repositories;
using Services.Expences;
using Domain.Expences;
using Web.Code;
using Domain;
using Services.Cache;
using Services.Statistics;
using Domain.Statistics;

namespace Web.App_Start
{
    public class ContainerInitializer
    {
        public static IContainer Initialize()
        {
            var builder = new ContainerBuilder();

            //Data Access
            builder.RegisterType<SecurityEnabledDatabaseInitializer>().AsImplementedInterfaces();
            builder.Register<DbContext>(c => new ProjectDbContext("ProjectConnection", c.Resolve<IDatabaseInitializer<ProjectDbContext>>()));
            builder.RegisterType<DbContextAdapter>().AsImplementedInterfaces().InstancePerHttpRequest();
            builder.RegisterType<UnitOfWork>().AsImplementedInterfaces().InstancePerHttpRequest();

            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerHttpRequest();
            builder.RegisterType<ExpenceCategoryRepository>().As<IExpenceCategoryRepository>().InstancePerHttpRequest();
            builder.RegisterType<ExpenceRepository>().As<IExpenceRepository>().InstancePerHttpRequest();
            builder.RegisterType<StatisticsRepository>().As<IStatisticsRepository>().InstancePerHttpRequest();

            //Singletons
            builder.RegisterType<DefaultMemoryCache>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<CacheKeyBuilderFactory>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<LifetimeManager>().AsImplementedInterfaces().SingleInstance();

            //Services
            builder.RegisterType<UsersService>().AsImplementedInterfaces().InstancePerHttpRequest();
            builder.RegisterType<ExpencesService>().AsImplementedInterfaces().InstancePerHttpRequest();
            builder.RegisterType<ExpenceCategoriesService>().AsImplementedInterfaces().InstancePerHttpRequest();
            builder.RegisterType<StatisticsService>().AsImplementedInterfaces().InstancePerHttpRequest();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var resolver = new AutofacWebApiDependencyResolver(container);
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = resolver;

            return container;
        }

    }
}