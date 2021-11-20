using System.Windows;
using System.Windows.Navigation;

namespace NuGetRestore.Wpf.Helpers
{
    /// <summary>
    /// Navigates pages
    /// </summary>
    public static class Navigator
    {
        /// <summary>
        /// Gets the navigation service.
        /// </summary>
        /// <value>
        /// The navigation service.
        /// </value>
        private static NavigationService NavigationService { get; } = (Application.Current.MainWindow as MainWindow).mainFrame.NavigationService;

        /// <summary>
        /// Navigates to the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="param">The parameter.</param>
        public static void Navigate(object page, object param = null)
        {
            NavigationService.Navigate(page, param);
        }

        /// <summary>
        /// Navigates back a page.
        /// </summary>
        public static void GoBack()
        {
            NavigationService.GoBack();
        }

        /// <summary>
        /// Navigate forward a page.
        /// </summary>
        public static void GoForward()
        {
            NavigationService.GoForward();
        }
    }
}
