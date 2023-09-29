using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;

namespace apiSimples.Configuration
{
    public static class apiSimplesConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            /*
             * config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;*/

            ///ADDING ROUTES - CONVENTION BASED ROUTES
            IHttpRoute defaultRoute = config.Routes.CreateRoute("api/{controller}/{id}", new { id = RouteParameter.Optional }, null);

            ///ADDING TO ROUTE TABLE
            config.Routes.Add("DefaultApi",defaultRoute);

            ///ADDING FORMATTERS
            JsonMediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}