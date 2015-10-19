using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RadBox_start.Helpers
{
    public static class Navigator
    {
        public static Frame MainWindowFrame;
        private static LandingPage landingPage = new LandingPage();
        private static MoviesAndShowsPage moviesAndShowsPage = new MoviesAndShowsPage();
        private static PicturesPage picturesPage = new PicturesPage();

        private static void Navigate(Page navigateTo)
        {
            MainWindowFrame.Navigate(navigateTo);
        }

        public static void LandingPage()
        {
            Navigate(landingPage);
        }

        public static void MoviesAndShowsPage()
        {
            Navigate(moviesAndShowsPage);
        }

        public static void PicturesPage()
        {
            Navigate(picturesPage);
        }
    }
}
