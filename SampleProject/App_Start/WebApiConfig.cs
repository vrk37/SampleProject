using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using SampleProject.Models;

namespace SampleProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<v1Product>("v1Product");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel()); //todo


        }
    }
}
