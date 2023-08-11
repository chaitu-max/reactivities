using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Presistence;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            
            var host=CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services=scope.ServiceProvider;

            try{
                var result = services.GetRequiredService<DataContext>();
                await result.Database.MigrateAsync();
                await seed.SeedData(result);
            }
            catch (Exception ex){
                var error = services.GetRequiredService<ILogger<Program>>();
                error.LogError(ex,"error during Migrations"+ex.Message);

            }
            await host.RunAsync();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
