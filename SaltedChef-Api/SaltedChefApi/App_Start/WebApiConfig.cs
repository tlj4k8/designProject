using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using SaltedChefLibrary;

namespace SaltedChefApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();
						ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
						builder.EntitySet<Availability>("Availabilities");
						builder.EntitySet<ClientMenu>("ClientMenus");
						builder.EntitySet<ClientNeed>("ClientNeeds");
						builder.EntitySet<Client>("Clients");
						builder.EntitySet<Employee>("Employees");
						builder.EntitySet<Menu>("Menus");
						builder.EntitySet<Person>("People");
						builder.EntitySet<Receipt>("Receipts");
						builder.EntitySet<Schedule>("Schedules");
						builder.EntitySet<TimeSheet>("TimeSheets");
						builder.EntitySet<ZipAvailability>("ZipAvailabilities");
						config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

			//config.Routes.MapHttpRoute(
			//    name: "DefaultApi",
			//    routeTemplate: "api/{controller}/{id}",
			//    defaults: new { id = RouteParameter.Optional }
			//);
		}
    }
}
