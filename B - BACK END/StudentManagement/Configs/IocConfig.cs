﻿using System.Data.Entity;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Business.Business;
using Business.Interfaces.Businesses;
using Database.Models.Contexts;
using Owin;
using SharedService.Interfaces.Repositories;
using SharedService.Interfaces.Services;
using SharedService.Repositories;
using SharedService.Services;
using SharedService.ViewModels;

namespace StudentManagement.Configs
{
    public class IocConfig
    {
        #region Methods

        /// <summary>
        /// Register inversion of controlers.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="httpConfiguration"></param>
        public static void Register(IAppBuilder app, HttpConfiguration httpConfiguration)
        {
            // Initiate container builder to register dependency injection.
            var containerBuilder = new ContainerBuilder();

            #region Controllers & hubs

            // Controllers & hubs
            containerBuilder.RegisterApiControllers(typeof(Startup).Assembly);

            #endregion

            #region Unit of work & Database context

            // Database context initialization.
            containerBuilder.RegisterType<RelationalDbContext>().As<DbContext>().InstancePerLifetimeScope();

            // Unit of work registration.
            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            // Services registration.
            containerBuilder.RegisterType<EncryptionService>().As<IEncryptionService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<IdentityService>().As<IIdentityService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<EmailService>().As<IEmailService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<SystemTimeService>().As<ISystemTimeService>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<ProfileCacheService>().As<IValueCacheService<int, ProfileViewModel>>()
                .SingleInstance();

            // Businesses registration.
            containerBuilder.RegisterType<SpecializedBusiness>().As<ISpecializedBusiness>().InstancePerLifetimeScope();

            #endregion

            #region IoC build

            // Container build.
            containerBuilder.RegisterWebApiFilterProvider(httpConfiguration);
            var container = containerBuilder.Build();

            // Attach DI resolver.
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Attach dependency injection into configuration.
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(httpConfiguration);

            #endregion
        }

        #endregion
    }
}