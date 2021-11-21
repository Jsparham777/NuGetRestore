using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading.Tasks;

namespace NuGetRestore.ConsoleApp
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.WithMachineName()
                //.MinimumLevel.Information()
                .WriteTo.Debug()
                .WriteTo.Console()
                //.WriteTo.File(new RenderedCompactJsonFormatter(), "Serilogs\\log.txt")
                .CreateLogger();

                Log.Information("Starting Host");

                using var host = CreateHostBuilder(args).Build();

                Console.WriteLine(GreetWithDependencyInjection(host.Services));

                return host.RunAsync();            
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureAppConfiguration(app =>
                {
                    app.AddJsonFile("appsettings.json");
                })
                .ConfigureServices(services =>
                {
                    services.AddTransient<IGreeter, ConsoleGreeter>();
                    services.AddTransient<IFooService, FooService>();
                });
        }

        public static string GreetWithDependencyInjection(IServiceProvider services)
        {
            using var serviceScope = services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var greeter = provider.GetRequiredService<IGreeter>();

            return greeter.Greet();
        }
    }
}
