using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Filters;
using Microsoft.Practices.Unity;
using nVision.Api.App_Start;
using nVision.Api.Models.accountHandler;
using nVision.Api.Models.authentication;
using nVision.Api.Models.interfaces;
using nVision.Api.Models.stubs;

namespace nVision.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var container = new UnityContainer();

            container.RegisterType<IAuthenticateWorkFlow, Authentication>(new HierarchicalLifetimeManager());
            container.RegisterType<IAccountWorkFlow, AccountWorkFlow>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            //Register the filter injector
            var providers = config.Services.GetFilterProviders().ToList();

            var defaultprovider = providers.Single(i => i is ActionDescriptorFilterProvider);
            config.Services.Remove(typeof(IFilterProvider), defaultprovider);

            config.Services.Add(typeof(IFilterProvider), new UnityFilterProvider(container));

      // Web API routes
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.Indent = true;
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
