using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vue_blog.Data;

    public static class Extensions
    {
        public static IHost MigrateDatabase(this IHost webHost)
        {
            // Manually run any pending migrations if configured to do so.
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (env == "Production")
            {
                var serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<AppDbContext>();

                dbContext.Database.Migrate();
            }
        }

            return webHost;
        }
    }
