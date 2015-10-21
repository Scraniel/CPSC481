using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using RadBox_start.Helpers;

namespace RadBox_start.Pages
{
    /// <summary>
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Page
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void powerButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void picturesButton_Click(object sender, RoutedEventArgs e)
        {
            Navigator.PicturesPage();
        }

        private void moviesAndShows_Click(object sender, RoutedEventArgs e)
        {
            Navigator.MoviesAndShowsPage();
        }
    }
}
