namespace NuGetRestore.WorkerService
{
    public class Settings
    {
        /// <summary>
        /// Worker service startup delay.
        /// </summary>
        public int StartupDelay { get; set; }

        /// <summary>
        /// Worker service poll rate.
        /// </summary>
        public int ServicePollRate { get; set; }

        /// <summary>
        /// HttpClient target server url for sending http requests.
        /// </summary>
        public string ServerUrl { get; set; }
    }
}