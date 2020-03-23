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
            var Host = CreateHostBuilder(args).Build().MigrateDatabase();
            using (var service = host.services.createscope())
            {
                var ctx = service.serviceprovider.getrequiredservice<appdbcontext>();

                if (!ctx.users.any())
                {
                    var usermanager = service.serviceprovider.getrequiredservice<usermanager<identityuser>>();
                    var adminpassword = environment.getenvironmentvariable("admin_password");
                    var admin = new identityuser { username = "admin" };
                    usermanager.createasync(admin, adminpassword).getawaiter().getresult();
                }
            };


            Host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
