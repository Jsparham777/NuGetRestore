using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NuGetRestore.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly Settings _settings;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="options"></param>
        public Worker(ILogger<Worker> logger, IOptions<Settings> options)
        {
            _logger = logger;
            _settings = options.Value;
        }

        /// <summary>
        /// Executes on startup.
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Startup delay
            Thread.Sleep(_settings.StartupDelay);

            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            while (!stoppingToken.IsCancellationRequested)
            {
                // Do some work here...
                _logger.LogCritical("I'm not doing any REAL work!");

                await Task.Delay(_settings.ServicePollRate, stoppingToken);
            }
        }
    }
}
