using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Versioning;
using Web.Api.Controllers;

namespace Web.Api.Configuration
{
    /// <summary>
    /// Swagger API documentation components start-up configuration
    /// </summary>
    public static class ApiVersioningConfiguration
    {
        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void ConfigureService(IServiceCollection services)
        {
            // Swagger API documentation
            services.AddApiVersioning(o => {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.ApiVersionReader = new HeaderApiVersionReader("api-version");
                o.Conventions.Controller<UserController>().HasApiVersion(new ApiVersion(1, 0));
                o.Conventions.Controller<LoginController>().HasApiVersion(new ApiVersion(1, 0));
            });
        }
    }
}
