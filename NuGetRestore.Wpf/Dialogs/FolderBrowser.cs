using System.Collections.Generic;
using System.IO;
using System.Linq;
using NuGetRestore.Wpf.Models;
using Ookii.Dialogs.Wpf;

namespace NuGetRestore.Wpf.Helpers
{
    /// <summary>
    /// Folder browser dialog
    /// </summary>
    public class FolderBrowser : IFolderBrowser
    {
        /// <summary>
        /// Gets or sets the window title.
        /// </summary>
        /// <value>
        /// The window title.
        /// </value>
        public string WindowTitle { get; set; } = "Select a folder";

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderBrowser"/> class.
        /// </summary>
        public FolderBrowser()
        {
        }

        /// <summary>
        /// Opens the browse dialog and returns a <see cref="FolderInfo" /> object for the selected directory.
        /// </summary>
        /// <returns></returns>
        public FolderInfo Browse()
        {
            FolderInfo folderInfo = new FolderInfo();

            var fbd = new VistaFolderBrowserDialog
            {
                ShowNewFolderButton = false,
                Description = WindowTitle,
                UseDescriptionForTitle = true
            };

            if (fbd.ShowDialog() == true && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                folderInfo.FileNames = new List<string>();

                folderInfo.FolderContents = Directory.GetDirectories(fbd.SelectedPath).ToList();
                folderInfo.FolderContents.AddRange(Directory.GetFiles(fbd.SelectedPath).ToList());

                foreach (var file in folderInfo.FolderContents)
                {
                    folderInfo.FileNames.Add(Path.GetFileName(file));
                }

                folderInfo.SelectedPath = fbd.SelectedPath;
            }

            return folderInfo;
        }
    }
}
