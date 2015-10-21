using RadBox_start.Helpers;
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

namespace RadBox_start
{
    /// <summary>
    /// Interaction logic for MoviesAndShows.xaml
    /// </summary>
    public partial class MoviesAndShowsPage : Page
    {
        public MoviesAndShowsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is the 'Click' event handler.
        /// </summary>
        /// <param name="sender"> The sender of the event.</param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigator.LandingPage(); 
        }
    }
}
