using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Environment.Shell;
using OrchardCore.Modules;
using Tweb.Users.DataAccess;

namespace Tweb.Users
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            var shellSettings = services.BuildServiceProvider().GetService<ShellSettings>();
            services.AddDbContext<TwebUserDbContext>(option =>
            {
                option.UseSqlServer(shellSettings["ConnectionString"]);
            });

            var userDbContext = services.BuildServiceProvider().GetService<TwebUserDbContext>();
            try
            {
                userDbContext.Database.Migrate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "Tweb.Users",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}