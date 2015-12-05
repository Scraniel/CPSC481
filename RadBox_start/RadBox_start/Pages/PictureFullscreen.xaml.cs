using RadBox_start.DataClasses;
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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class PictureFullscreen : Page
    {
        public System.Windows.Threading.DispatcherTimer dispatcherTimer;
        bool _slideshowOn;
        BitmapImage _slideshowOnPicture, _slideshowOffPicture;

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (_slideshowOn)
                RightArrow_Click(RightArrow, new RoutedEventArgs());
        }

        public PictureFullscreen()
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            _slideshowOnPicture = new BitmapImage(new Uri("/RadBox_start;component/Assets/Images/Pictures/slideshow_image.png", UriKind.Relative));
            _slideshowOffPicture = new BitmapImage(new Uri("/RadBox_start;component/Assets/Images/Pictures/slideshow_off_image.png", UriKind.Relative));
            InitializeComponent();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            _slideshowOn = true;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigator.PicturesPage();
            dispatcherTimer.Stop();
        }

        private void RightArrow_Click(object sender, RoutedEventArgs e)
        {

            var data = DataContext as PicturesData;
            data.ShiftRight();
            data.CurrentlySelected = data.Images[1];
        }

        private void LeftArrow_Click(object sender, RoutedEventArgs e)
        {

            var data = DataContext as PicturesData;
            data.ShiftLeft();
            data.CurrentlySelected = data.Images[1];
        }

        private void SlideShowButton_Click(object sender, RoutedEventArgs e)
        {
            Image slideshowImage = SlideShowButton.Content as Image;
            if (_slideshowOn)
            {
                slideshowImage.Source = _slideshowOffPicture;
                _slideshowOn = false;
            }
            else
            {
                slideshowImage.Source = _slideshowOnPicture;
                _slideshowOn = true;
            }
        }
    }
}
