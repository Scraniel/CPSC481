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
        TimeSpan OneSecond = new TimeSpan(0, 0, 1);

        BitmapImage MuteIcon = new BitmapImage(new Uri(@"/RadBox_start;component\Assets\Images\MoviesAndShows\muted.png", UriKind.Relative));
        BitmapImage UnmuteIcon = new BitmapImage(new Uri(@"/RadBox_start;component\Assets\Images\MoviesAndShows\volumeControlsFiller.png", UriKind.Relative));
        double currentVolume = 50;

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

        private void Rewind_Click(object sender, RoutedEventArgs e)
        {
            long newPosition = (((Video.Position.Ticks - OneSecond.Ticks) % Video.NaturalDuration.TimeSpan.Ticks) + Video.NaturalDuration.TimeSpan.Ticks) % Video.NaturalDuration.TimeSpan.Ticks;

            Video.Position = TimeSpan.FromTicks(newPosition);
        }

        private void Fastforward_Click(object sender, RoutedEventArgs e)
        {
            long newPosition = (Video.Position.Ticks + OneSecond.Ticks) % Video.NaturalDuration.TimeSpan.Ticks;

            Video.Position = TimeSpan.FromTicks(newPosition);
        }

        private void Video_MouseEnter(object sender, MouseEventArgs e)
        {
            Rewind.Opacity = 1;
            Fastforward.Opacity = 1;
        }

        private void Video_MouseLeave(object sender, MouseEventArgs e)
        {
            Rewind.Opacity = 0;
            Fastforward.Opacity = 0;
        }

        private void PlaybackControls_MouseLeave(object sender, MouseEventArgs e)
        {
            Rewind.Opacity = 0;
            Fastforward.Opacity = 0;
        }

        private void PlaybackControls_MouseEnter(object sender, MouseEventArgs e)
        {
            Rewind.Opacity = 1;
            Fastforward.Opacity = 1;
        }

        private void Video_MediaEnded(object sender, RoutedEventArgs e)
        {
            Video.Position = new TimeSpan(0);
        }

        private void VolumeButton_Click(object sender, RoutedEventArgs e)
        {
            if(Video.IsMuted)
            {
                unmute();
            }
            else
            {
                mute();
            }
            
        }

        private void Volume_ValueChanged(object sender, RoutedEventArgs e)
        {
           Video.Volume = Volume.Value / Volume.Maximum;
        }

        private void mute()
        {
            Video.IsMuted = true;
            currentVolume = Volume.Value;
            Volume.Value = 0;
            var image = VolumeButton.Content as Image;
            if(image != null)
                image.Source = MuteIcon;
            
        }

        private void unmute()
        {
            Video.IsMuted = false;
            Volume.Value = currentVolume;
            var image = VolumeButton.Content as Image;
            if (image != null)
                image.Source = UnmuteIcon;
        }
    }
}
