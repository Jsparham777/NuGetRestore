using NuGetRestore.Wpf.Animations;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NuGetRestore.Wpf.Pages
{
    /// <summary>
    /// A base page for all pages to gain base functionality 
    /// </summary>
    public class BasePage : Page
    {
        #region Properties
        /// <summary>
        /// The animation to play when the page is loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// The animation to play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// The time any slide animation takes to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;
        #endregion

        #region Constructor
        /// <summary>
        /// Deafult constructor
        /// </summary>
        public BasePage()
        {
            //Hide the page if animating in 
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            //Listen out for the page loading
            Loaded += BasePage_LoadedAsync;
        }
        #endregion

        #region Animation load/unload
        /// <summary>
        /// Once the page is loaded, perform any required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_LoadedAsync(object sender, RoutedEventArgs e)
        {
            await AnimateInAsync();
        }

        /// <summary>
        /// Animates this page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateInAsync()
        {
            //Check if an animation is to be started
            if (PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    //Start the animation
                    await this.SlideAndFadeInFromRightAsync(SlideSeconds);
                    break;

                case PageAnimation.SlideAndFadeInFromLeft:
                    //Start the animation
                    await this.SlideAndFadeInFromLeftAsync(SlideSeconds);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Animates this page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOutAsync()
        {
            //Check if an animation is to be started
            if (PageUnloadAnimation == PageAnimation.None)
                return;

            switch (PageUnloadAnimation)
            {                
                case PageAnimation.SlideAndFadeOutToLeft:
                    //Start the animation
                    await this.SlideAndFadeOutToLeftAsync(SlideSeconds);
                    break;

                case PageAnimation.SlideAndFadeOutToRight:
                    //Start the animation
                    await this.SlideAndFadeOutToRightAsync(SlideSeconds);
                    break;

                default:
                    break;
            }
        }
        #endregion
    }
}
