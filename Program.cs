using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans.Hosting;

namespace Sarmady.Orleans
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                .UseOrleans(builder =>
                {
                    builder.UseLocalhostClustering();
                    builder.AddDynamoDBGrainStorageAsDefault(optionsBuilder =>
                    {
                        optionsBuilder.Service = "http://localhost:4566";
                        optionsBuilder.UseJson = true;
                    });
                });
    }
}
