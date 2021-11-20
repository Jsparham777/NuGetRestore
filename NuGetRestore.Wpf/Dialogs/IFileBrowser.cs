namespace NuGetRestore.Wpf.Helpers
{
    /// <summary>
    /// File Browser interface
    /// </summary>
    public interface IFileBrowser
    {
        /// <summary>
        /// Gets or sets the window title.
        /// </summary>
        /// <value>
        /// The window title.
        /// </value>
        public string WindowTitle { get; set; }

        /// <summary>
        /// Gets or sets the filter extension.
        /// </summary>
        /// <value>
        /// The filter extension.
        /// </value>
        public string FilterExtension { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to verify if the file exists.
        /// </summary>
        /// <value>
        ///   <c>true</c> if file exists; otherwise, <c>false</c>.
        /// </value>
        public bool VerifyFileExists { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to verify the path exists.
        /// </summary>
        /// <value>
        ///   <c>true</c> if path exists; otherwise, <c>false</c>.
        /// </value>
        public bool VerifyPathExists { get; set; }

        /// <summary>
        /// Opens the file browser dialog and returns the selected file path.
        /// </summary>
        /// <returns>The selected file path</returns>
        string Browse();
    }
}