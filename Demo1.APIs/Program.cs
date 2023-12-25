using Demo1.Repository.Data.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1.APIs
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var kestrel = CreateHostBuilder(args).Build();

            using var ServiceScope = kestrel.Services.CreateScope();
            var services = ServiceScope.ServiceProvider;
			var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var DbCtx = services.GetRequiredService<CompanyContext>();

                await DbCtx.Database.MigrateAsync();
                await CompanySeedContext.SeedAsync(DbCtx, loggerFactory);
            }
            catch (Exception ex) 
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError("Proram.cs", ex.Message);
            }

            kestrel.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
