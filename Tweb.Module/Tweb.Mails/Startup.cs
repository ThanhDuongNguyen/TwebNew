using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Environment.Shell;
using OrchardCore.Modules;
using Tweb.Mails.DataAccess;

namespace Tweb.Mails
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            var shellSettings = services.BuildServiceProvider().GetService<ShellSettings>();
            services.AddDbContext<TwebMailDbContext>(option =>
            {
                option.UseSqlServer(shellSettings["ConnectionString"]);
            });


            var mailDbContext = services.BuildServiceProvider().GetService<TwebMailDbContext>();
            try
            {
                mailDbContext.Database.Migrate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            mailDbContext.Add(new Mail { Sender = "TD", MailProvider = "google", Content = "hello" });
            mailDbContext.SaveChanges();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "Tweb.Mails",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}