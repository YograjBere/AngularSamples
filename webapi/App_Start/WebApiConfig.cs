﻿namespace webapi
{
    using System.Web.Http;
    using Microsoft.Owin.Security.OAuth;
    using Autofac;
    using Infrastructure.Repository;
    using Autofac.Integration.WebApi;
    using System.Reflection;
    using Models;
    using FluentValidation.WebApi;
    using System.Web.Http.ExceptionHandling;
    using Infrastructure.ErrorHandler;
    using Infrastructure.Logger;
    using Newtonsoft.Json.Serialization;
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            // config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
            RegisterDependencies();
            RegisterValidator(config);
        }

        private static void RegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            builder.RegisterType(typeof(StudentDbContext));
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
            builder.RegisterType<GlobalExceptionHandler>().As<IExceptionHandler>();
            builder.RegisterType<Logger>().As<ILogger>();

            var container = builder.Build();
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterValidator(HttpConfiguration config)
        {
            FluentValidationModelValidatorProvider.Configure(config);
        }
    }
}
