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

namespace RadBox_start.Pages
{
    /// <summary>
    /// Interaction logic for PicturesPage.xaml
    /// </summary>
    public partial class PicturesPage : Page
    {
        public PicturesPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigator.LandingPage(); 
        }

        private void photoPlay(object sender, RoutedEventArgs e)
        {
            Navigator.PictureFullScreen();
        }
    }
}
