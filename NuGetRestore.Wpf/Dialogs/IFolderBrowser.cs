using NuGetRestore.Wpf.Models;

namespace NuGetRestore.Wpf.Helpers
{
    /// <summary>
    /// Folder browser dialog
    /// </summary>
    public interface IFolderBrowser
    {
        /// <summary>
        /// Gets or sets the window title.
        /// </summary>
        /// <value>
        /// The window title.
        /// </value>
        public string WindowTitle { get; set; }

        /// <summary>
        /// Opens the browse dialog and returns a <see cref="FolderInfo"/> object for the selected directory.
        /// </summary>
        /// <returns></returns>
        FolderInfo Browse();
    }
}