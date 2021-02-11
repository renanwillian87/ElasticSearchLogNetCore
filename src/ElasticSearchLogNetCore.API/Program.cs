using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace ElasticSearchLogNetCore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog(configureLogger: (hostContext, loggerConfiguration) => {
                    loggerConfiguration
                        .Enrich.FromLogContext()
                        .Enrich.WithMachineName()
                        .WriteTo.Console()
                        .WriteTo.Elasticsearch(
                            new ElasticsearchSinkOptions(new Uri(hostContext.Configuration["ElasticConfiguration:Uri"]))
                            {

                                IndexFormat = $"{hostContext.Configuration["ApplicationName"]}-logs-{hostContext.HostingEnvironment.EnvironmentName?.ToLower().Replace(".","-")}-{DateTime.UtcNow:yyy-mm}",
                                AutoRegisterTemplate = true,
                                NumberOfShards = 2,
                                NumberOfReplicas = 1
                            }
                        )
                        .Enrich.WithProperty("Environmen", hostContext.HostingEnvironment.EnvironmentName)
                        .ReadFrom.Configuration(hostContext.Configuration);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
