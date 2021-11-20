using System.Collections.Generic;

namespace NuGetRestore.Wpf.Models
{
    /// <summary>
    /// Folder information interface
    /// </summary>
    public interface IFolderInfo
    {
        /// <summary>
        /// Gets or sets the file names with the folder.
        /// </summary>
        /// <value>
        /// The file names within the folder.
        /// </value>
        List<string> FileNames { get; set; }

        /// <summary>
        /// Gets or sets the folder contents.
        /// </summary>
        /// <value>
        /// The folder contents.
        /// </value>
        List<string> FolderContents { get; set; }

        /// <summary>
        /// Gets or sets the selected path.
        /// </summary>
        /// <value>
        /// The selected path.
        /// </value>
        string SelectedPath { get; set; }
    }
}