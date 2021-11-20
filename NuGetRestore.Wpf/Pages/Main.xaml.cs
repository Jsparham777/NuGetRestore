using System.Windows;

namespace NuGetRestore.Wpf.Pages
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : BasePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the ButtonRunDAT control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonRunDAT_Click(object sender, RoutedEventArgs e)
        { 
            //Navigator.Navigate(new BrowseUUTFolder());
        }

        /// <summary>
        /// Handles the Click event of the ButtonOpenMAT control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonOpenMAT_Click(object sender, RoutedEventArgs e)
        {
            //Navigator.Navigate(new BrowseMATFile());
        }
    }
}
