using System.Threading.Tasks;

namespace NuGetRestore.Wpf.Helpers
{
    /// <summary>
    /// Save dialog interface
    /// </summary>
    public interface ISaveDialog
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        string Filter { get; set; }

        /// <summary>
        /// Gets or sets the window title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        string Title { get; set; }

        /// <summary>
        /// Saves the content to file.
        /// </summary>
        /// <param name="defaultFilename">The default filename.</param>
        /// <param name="content">The content.</param>
        /// <returns>True if successfully saved</returns>
        Task<bool> SaveFileAsync(string defaultFilename, string content);
    }
}