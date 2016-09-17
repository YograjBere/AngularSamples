using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Autofac;
using webapi.Infrastructure.Repository;
using Autofac.Integration.WebApi;
using System.Reflection;
using webapi.Models;
using System.Web.Mvc;
using FluentValidation.WebApi;
using System.Web.Http.ExceptionHandling;
using webapi.Infrastructure.ErrorHandler;

namespace webapi
{
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
            var container = builder.Build();
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //DependencyResolver.SetResolver(new AutofacWebApiDependencyResolver(container));
        }

        private static void RegisterValidator(HttpConfiguration config)
        {
            FluentValidationModelValidatorProvider.Configure(config);
        }
    }
}
