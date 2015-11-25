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

namespace RadBox_start.UserControls
{
    /// <summary>
    /// Interaction logic for HomeButton.xaml
    /// </summary>
    public partial class HomeButton : UserControl
    {
        public HomeButton()
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
