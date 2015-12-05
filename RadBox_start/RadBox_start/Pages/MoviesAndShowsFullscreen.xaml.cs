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
using RadBox_start.DataClasses;

namespace RadBox_start.Pages
{
    /// <summary>
    /// Interaction logic for MoviesAndShowsFullscreen.xaml
    /// </summary>
    public partial class MoviesAndShowsFullscreen : Page
    {
        public MoviesAndShowsData data = new MoviesAndShowsData();

        public MoviesAndShowsFullscreen()
        {
            InitializeComponent();

            DataContext = data;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigator.MoviesAndShowsPage();
        }

        private void Video_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Button_Click(BackButton, new RoutedEventArgs());
        }
    }
}
