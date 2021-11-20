using Microsoft.Extensions.Options;

namespace NuGetRestore.Wpf.ViewModels
{
    /// <summary>
    /// Main window view model
    /// </summary>
    /// <seealso cref="BaseViewModel" />
    public class MainWindowViewModel : BaseViewModel
    {
        /// <summary>
        /// The window title
        /// </summary>
        public string WindowTitle { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public MainWindowViewModel(IOptions<AppSettings> settings)
        {
            switch (settings.Value.Environment.ToLower())
            {
                case "production":
                    WindowTitle = "DAT Runner";
                    break;
                case "development":
                    WindowTitle = "DAT Runner [DEVELOPMENT]";
                    break;
                default:
                    break;
            }
        }
    }
}