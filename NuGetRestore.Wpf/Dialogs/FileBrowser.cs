using Ookii.Dialogs.Wpf;

namespace NuGetRestore.Wpf.Helpers
{
    /// <summary>
    /// File browser dialog
    /// </summary>
    public class FileBrowser : IFileBrowser
    {
        /// <summary>
        /// Gets or sets the window title.
        /// </summary>
        /// <value>
        /// The window title.
        /// </value>
        public string WindowTitle { get; set; } = "Select a file";

        /// <summary>
        /// Gets or sets the filter extension.
        /// </summary>
        /// <value>
        /// The filter extension.
        /// </value>
        public string FilterExtension { get; set; } //TODO: make this a list<string> for multiple extensions

        /// <summary>
        /// Gets or sets a value indicating whether to verify if the file exists.
        /// </summary>
        /// <value>
        ///   <c>true</c> if file exists; otherwise, <c>false</c>.
        /// </value>
        public bool VerifyFileExists { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether to verify the path exists.
        /// </summary>
        /// <value>
        ///   <c>true</c> if path exists; otherwise, <c>false</c>.
        /// </value>
        public bool VerifyPathExists { get; set; } = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileBrowser"/> class.
        /// </summary>
        public FileBrowser()
        {
        }

        /// <summary>
        /// Opens the file browser dialog and returns the selected file path.
        /// </summary>
        /// <returns>
        /// The selected file path
        /// </returns>
        public string Browse()
        {
            var openFileDialog = new VistaOpenFileDialog()
            {
                Title = WindowTitle,
                Filter = $"{FilterExtension.ToUpper()} File (*{FilterExtension})|*{FilterExtension}",
                CheckFileExists = VerifyFileExists, 
                CheckPathExists = VerifyPathExists,
            };

            if (openFileDialog.ShowDialog() == true && !string.IsNullOrWhiteSpace(openFileDialog.FileName))
                return openFileDialog.FileName;

            return "";
        }
    }
}
