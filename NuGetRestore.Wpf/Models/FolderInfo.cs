using System.Collections.Generic;

namespace NuGetRestore.Wpf.Models
{
    /// <summary>
    /// Folder information
    /// </summary>
    /// <seealso cref="IFolderInfo" />
    public class FolderInfo : IFolderInfo
    {
        /// <summary>
        /// Gets or sets the folder contents.
        /// </summary>
        /// <value>
        /// The folder contents.
        /// </value>
        public List<string> FolderContents { get; set; }

        /// <summary>
        /// Gets or sets the selected path.
        /// </summary>
        /// <value>
        /// The selected path.
        /// </value>
        public string SelectedPath { get; set; }

        /// <summary>
        /// Gets or sets the file names with the folder.
        /// </summary>
        /// <value>
        /// The file names within the folder.
        /// </value>
        public List<string> FileNames { get; set; }
    }
}
