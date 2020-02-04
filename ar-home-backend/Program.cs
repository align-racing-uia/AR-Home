using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using web_api.Data;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace web_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                // Get our database context from the service provider
                var context = services.GetRequiredService<ApplicationDbContext>();

                // Get the environment so we can check if this is running in development or otherwise
                var environment = services.GetService<IHostEnvironment>();

                // Initialise the database using the initializer from Data/ExampleDbInitializer.cs
                ApplicationDbInitializer.Initialize(context, environment.IsDevelopment());
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}