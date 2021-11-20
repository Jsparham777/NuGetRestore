using Microsoft.Win32;
using System.IO;
using System.Threading.Tasks;

namespace NuGetRestore.Wpf.Helpers
{
    /// <summary>
    /// Save dialog
    /// </summary>
    /// <seealso cref="DATRunner.Helpers.ISaveDialog" />
    public class SaveDialog : ISaveDialog
    {
        /// <summary>
        /// Gets or sets the window title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; } = "Save file";

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public string Filter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveDialog"/> class.
        /// </summary>
        public SaveDialog()
        {
        }

        /// <summary>
        /// Saves the content to file.
        /// </summary>
        /// <param name="defaultFilename">The default filename.</param>
        /// <param name="content">The content.</param>
        /// <returns>True if successfully saved</returns>
        public async Task<bool> SaveFileAsync(string defaultFilename, string content)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog()
                {
                    Title = Title,
                    Filter = Filter,
                    FileName = Path.GetFileNameWithoutExtension(defaultFilename)
                };

                if (saveDialog.ShowDialog() == true)
                {
                    await SaveToFileAsync(saveDialog.FileName, content);
                }
                return true;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Saves the content to file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="content">The content.</param>
        /// <returns>An awaitable <see cref="Task"/></returns>
        private async Task SaveToFileAsync(string filename, string content)
        {
            try
            {
                using StreamWriter outputFile = new StreamWriter(filename);
                await outputFile.WriteAsync(content);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
