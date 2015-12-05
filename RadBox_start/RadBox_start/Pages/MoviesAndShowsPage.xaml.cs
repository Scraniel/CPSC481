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
    /// Interaction logic for MoviesAndShows.xaml
    /// </summary>
    public partial class MoviesAndShowsPage : Page
    {
        PicturesData data = new PicturesData();

        public MoviesAndShowsPage()
        {
            InitializeComponent();
            DataContext = data;

            Scroller.RightArrowClick += new RoutedEventHandler(RightArrow_Click);
            Scroller.LeftArrowClick += new RoutedEventHandler(LeftArrow_Click);
            Scroller.SelectionChanged += new SelectionChangedEventHandler(Thumbnails_SelectionChanged);

            data.Add(@"\RadBox_start;component\Assets\Images\MoviesAndShows\lego.png");
            data.Add(@"\RadBox_start;component\Assets\Images\MoviesAndShows\bunny.PNG");
            data.Add(@"\RadBox_start;component\Assets\Images\MoviesAndShows\letitgo.png");
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

        private void Screen_Click(object sender, RoutedEventArgs e)
        {

            Navigator.MoviesAndShowsFullscreen((data._currentStart + 1) % PicturesData.MAX_SHOWN, MoviesAndShowsData.MovieType.All);
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            Navigator.MoviesAndShowsFullscreen((data._currentStart + 1) % PicturesData.MAX_SHOWN, MoviesAndShowsData.MovieType.All);
        }

        private void OpenCategories_Click(object sender, RoutedEventArgs e)
        {
            CategoriesList.Visibility = Visibility.Visible;
        }

        private void CategoriesList_MouseLeave(object sender, MouseEventArgs e)
        {
            CategoriesList.Visibility = Visibility.Collapsed;
        }

        private void MoviesButton_Click(object sender, RoutedEventArgs e)
        {
            EpisodesList.Visibility = Visibility.Collapsed;
        }

        private void TVShowsButton_Click(object sender, RoutedEventArgs e)
        {
            EpisodesList.Visibility = Visibility.Visible;
        }

        private void RightArrow_Click(object sender, RoutedEventArgs e)
        {

            data.ShiftRight();
            Scroller.Thumbnails.SelectedIndex = 1;
        }

        private void LeftArrow_Click(object sender, RoutedEventArgs e)
        {

            data.ShiftLeft();
            Scroller.Thumbnails.SelectedIndex = 1;
        }

        private void Thumbnails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = Scroller.Thumbnails.SelectedIndex;
            e.Handled = true;
            if (index == -1)
                Scroller.Thumbnails.SelectedIndex = 1;

            if (index == PicturesData.BEGINNING)
                LeftArrow_Click(Scroller.LeftArrow, new RoutedEventArgs());
            else if (index == PicturesData.END)
                RightArrow_Click(Scroller.RightArrow, new RoutedEventArgs());


            data.CurrentlySelected = data.Images[Scroller.Thumbnails.SelectedIndex];
        }
    }
}
