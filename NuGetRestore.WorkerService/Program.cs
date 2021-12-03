using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Serilog;
using System;

namespace NuGetRestore.WorkerService
{
    public class Program
    {
        /// <summary>
        /// Application main entry point.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Debug()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Starting Web Host");

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        /// <summary>
        /// Creates the <see cref="IHostBuilder"/> and registers services in the IoC container.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        /// <returns>An <see cref="IHostBuilder"/>.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                // Windows target environment
                .UseWindowsService(options =>
                {
                    options.ServiceName = "A worker service!";
                })

                // Linux target environment
                .UseSystemd()

                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;
                    services.Configure<Settings>(configuration.GetSection(nameof(Settings)));

                    services.AddHostedService<Worker>();

                    // Add services here

                    // Add a HTTP client so this worker service can send outbound requests
                    services.AddHttpClient("RESTapi", client =>
                    {
                        // Set the target server url
                        client.BaseAddress = new Uri(configuration[$"{nameof(Settings)}:{nameof(Settings.ServerUrl)}"]);

                        // Add request header auth here
                        client.DefaultRequestHeaders.Add("Accept", "some authentication string");
                    })

                    // Add Polly for HTTP retry
                    .AddTransientHttpErrorPolicy(x => x.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(300)));
                })
            .UseSerilog();
    }
}
