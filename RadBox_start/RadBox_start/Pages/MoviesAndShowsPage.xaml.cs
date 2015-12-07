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
        MoviesAndShowsData.MovieType currentType = MoviesAndShowsData.MovieType.All;
        List<MoviesMetadata> cartoonPics = new List<MoviesMetadata>();
        List<MoviesMetadata> actionPics = new List<MoviesMetadata>();
        List<MoviesMetadata> singalongPics = new List<MoviesMetadata>();

        public MoviesAndShowsPage()
        {
            InitializeComponent();
            DataContext = data;
            Scroller.Thumbnails.SelectedIndex = 1;
            Scroller.RightArrowClick += new RoutedEventHandler(RightArrow_Click);
            Scroller.LeftArrowClick += new RoutedEventHandler(LeftArrow_Click);
            Scroller.SelectionChanged += new SelectionChangedEventHandler(Thumbnails_SelectionChanged);

            actionPics.Add(new MoviesMetadata(@"\RadBox_start;component\Assets\Images\MoviesAndShows\Lego.png"));
            actionPics.Add(new MoviesMetadata(@"\RadBox_start;component\Assets\Images\MoviesAndShows\Honey, I Shrunk The Kids.png"));
            actionPics.Add(new MoviesMetadata(@"\RadBox_start;component\Assets\Images\MoviesAndShows\The Goonies.png"));

            cartoonPics.Add(new MoviesMetadata(@"\RadBox_start;component\Assets\Images\MoviesAndShows\The Amazing Bunny.PNG"));
            cartoonPics.Add(new MoviesMetadata(@"\RadBox_start;component\Assets\Images\MoviesAndShows\Spongebob.png"));
            cartoonPics.Add(new MoviesMetadata(@"\RadBox_start;component\Assets\Images\MoviesAndShows\Spirited Away.png"));

            singalongPics.Add(new MoviesMetadata(@"\RadBox_start;component\Assets\Images\MoviesAndShows\Let It Go.png"));
            singalongPics.Add(new MoviesMetadata(@"\RadBox_start;component\Assets\Images\MoviesAndShows\ABC Song.png"));
            singalongPics.Add(new MoviesMetadata(@"\RadBox_start;component\Assets\Images\MoviesAndShows\Fun Song.png"));

            data.Add(actionPics);
            data.Add(cartoonPics);
            data.Add(singalongPics);


            MoviesButton.IsEnabled = false;
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
            Navigator.MoviesAndShowsFullscreen(GetTrueCurrentIndex(), GetCurrentlyPlaying().Position, currentType);
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            Navigator.MoviesAndShowsFullscreen(GetTrueCurrentIndex(), GetCurrentlyPlaying().Position, currentType);
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
            MoviesButton.IsEnabled = false;
            TVShowsButton.IsEnabled = true;
            EpisodesList.Visibility = Visibility.Collapsed;
        }

        private void TVShowsButton_Click(object sender, RoutedEventArgs e)
        {
            TVShowsButton.IsEnabled = false;
            MoviesButton.IsEnabled = true;
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
                return;

            if (index == PicturesData.BEGINNING)
                LeftArrow_Click(Scroller.LeftArrow, new RoutedEventArgs());
            else if (index == PicturesData.END)
                RightArrow_Click(Scroller.RightArrow, new RoutedEventArgs());


            data.CurrentlySelected = data.Images[Scroller.Thumbnails.SelectedIndex];
        }

        private void CartoonsButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentType != MoviesAndShowsData.MovieType.Cartoons)
            {
                data.Clear();
                data.Add(cartoonPics);
                currentType = MoviesAndShowsData.MovieType.Cartoons;
                Scroller.Thumbnails.SelectedIndex = 1;
            }
            CategoriesList.Visibility = Visibility.Collapsed;
            
        }

        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentType != MoviesAndShowsData.MovieType.Action)
            {
                data.Clear();
                data.Add(actionPics);
                currentType = MoviesAndShowsData.MovieType.Action;
                Scroller.Thumbnails.SelectedIndex = 1;
            }
            CategoriesList.Visibility = Visibility.Collapsed;
        }

        private void SingalongButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentType != MoviesAndShowsData.MovieType.Singalong)
            {
                data.Clear();
                data.Add(singalongPics);
                currentType = MoviesAndShowsData.MovieType.Singalong;
                Scroller.Thumbnails.SelectedIndex = 1;
            }
            CategoriesList.Visibility = Visibility.Collapsed;
        }

        private void AllButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentType != MoviesAndShowsData.MovieType.All)
            {
                data.Clear();
                data.Add(actionPics);
                data.Add(cartoonPics);
                data.Add(singalongPics);
                currentType = MoviesAndShowsData.MovieType.All;
                Scroller.Thumbnails.SelectedIndex = 1;
            }
            CategoriesList.Visibility = Visibility.Collapsed;
        }

        public int GetTrueCurrentIndex()
        {
            return (data._currentStart + 1) % data._allImages.Count;
        }

        public void UpdateMetaData(bool watched, TimeSpan position)
        {
            MoviesMetadata CurrentlyPlaying = GetCurrentlyPlaying();
            if (CurrentlyPlaying != null)
            {
                CurrentlyPlaying.Position = position;
                if (watched && !CurrentlyPlaying.Seen)
                {
                    CurrentlyPlaying.Seen = watched;
                    List<string> path = new List<string>(CurrentlyPlaying.Path.Split('\\'));
                    int insertIndex = path.IndexOf("MoviesAndShows");
                    if (insertIndex >= 0)
                    {
                        path.Insert(insertIndex + 1, "GreyScale");
                        string newPath = String.Join("\\", path);
                        data.Update(CurrentlyPlaying.Path, newPath);
                        CurrentlyPlaying.Path = newPath;
                    }
                }
            }
        }

        public MoviesMetadata GetCurrentlyPlaying()
        {
            int index = GetTrueCurrentIndex();
            MoviesMetadata CurrentlyPlaying = null;

            switch (currentType)
            {
                case MoviesAndShowsData.MovieType.All:
                    if (index < actionPics.Count)
                        CurrentlyPlaying = actionPics[index];
                    else if (index - actionPics.Count < cartoonPics.Count)
                        CurrentlyPlaying = cartoonPics[index - actionPics.Count];
                    else
                        CurrentlyPlaying = singalongPics[index - actionPics.Count - cartoonPics.Count];
                    break;
                case MoviesAndShowsData.MovieType.Action:
                    CurrentlyPlaying = actionPics[index];
                    break;
                case MoviesAndShowsData.MovieType.Cartoons:
                    CurrentlyPlaying = cartoonPics[index];
                    break;
                case MoviesAndShowsData.MovieType.Singalong:
                    CurrentlyPlaying = singalongPics[index];
                    break;
            }

            return CurrentlyPlaying;
        }
    }
}
