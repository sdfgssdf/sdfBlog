using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using vue_blog.Data;

namespace vue_blog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Host = CreateHostBuilder(args).Build();
            //using (var service = Host.Services.CreateScope())
            //{
            //    var ctx = service.ServiceProvider.GetRequiredService<AppDbContext>();

            //    if (!ctx.Users.Any())
            //    {
            //        var usermanager = service.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            //        var adminpassword = Environment.GetEnvironmentVariable("admin_password");
            //        var admin = new IdentityUser { UserName = "admin" };
            //        usermanager.CreateAsync(admin, adminpassword).GetAwaiter().GetResult();
            //    }
            //};


            Host.MigrateDatabase().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
