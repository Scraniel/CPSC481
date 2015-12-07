using RadBox_start.DataClasses;
using RadBox_start.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        PicturesData data = new PicturesData();
        //FoldersWrapper folders = new FoldersWrapper();
        public ObservableCollection<PictureFolderData> FolderData = new ObservableCollection<PictureFolderData>();


        public PicturesPage()
        {
            InitializeComponent(); 
            DataContext = data;
            Scroller.Thumbnails.SelectedIndex = 1;

            Scroller.RightArrowClick += new RoutedEventHandler(RightArrow_Click);
            Scroller.LeftArrowClick += new RoutedEventHandler(LeftArrow_Click);
            Scroller.SelectionChanged += new SelectionChangedEventHandler(Thumbnails_SelectionChanged);

            FolderData.Add(new PictureFolderData(@"/RadBox_start;component\Assets\Images\Pictures\FoldersImage.png", "All", new List<string>()));
            FolderData.Add(new PictureFolderData(@"\RadBox_start;component\Assets\Images\Pictures\Pencils.png", "School", new List<string>()));
            FolderData.Add(new PictureFolderData(@"/RadBox_start;component\Assets\Images\MoviesAndShows\videoFiller.png", "Landscapes", new List<string>()));
            FolderData.Add(new PictureFolderData(@"/RadBox_start;component\Assets\Images\MoviesAndShows\thumbnailFiller.png", "Fishes", new List<string>()));
            
            FoldersSelector.DataContext = FolderData;
                        
            FolderData[1].Images.Add(@"\RadBox_start;component\Assets\Images\Pictures\Blue Pencils.png");
            FolderData[1].Images.Add(@"\RadBox_start;component\Assets\Images\Pictures\Pencils.png");
            FolderData[1].Images.Add(@"\RadBox_start;component\Assets\Images\Pictures\Red Pencils.png");
            FolderData[1].Images.Add(@"\RadBox_start;component\Assets\Images\Pictures\Yellow Pencils.png");
                        
            FolderData[2].Images.Add(@"\RadBox_start;component\Assets\Images\Pictures\Dark Day.png");
            FolderData[2].Images.Add(@"\RadBox_start;component\Assets\Images\Pictures\Daytime.png");
            FolderData[2].Images.Add(@"\RadBox_start;component\Assets\Images\Pictures\Burgandy Sky.png");
            FolderData[2].Images.Add(@"\RadBox_start;component\Assets\Images\Pictures\Purple Sun.png");

            FolderData[3].Images.Add(@"\RadBox_start;component\Assets\Images\Pictures\Red Fish.png");
            FolderData[3].Images.Add(@"/RadBox_start;component\Assets\Images\Pictures\Fish.png");
            FolderData[3].Images.Add(@"\RadBox_start;component\Assets\Images\Pictures\Red Sky.png");
            FolderData[3].Images.Add(@"\RadBox_start;component\Assets\Images\Pictures\Yellow Sky.png");

            FolderData[0].Add(FolderData[1].Images);
            FolderData[0].Add(FolderData[2].Images);
            FolderData[0].Add(FolderData[3].Images);
            
            data.Add(FolderData[0].Images);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigator.LandingPage(); 
        }

        private void photoPlay(object sender, RoutedEventArgs e)
        {
            Navigator.PictureFullScreen(data);
        }

        private void FoldersButton_Click(object sender, RoutedEventArgs e)
        {
            TranslateTransform translate = new TranslateTransform();
            translate.X = 230;

            FoldersSelector.RenderTransform = translate;
        }

        private void FoldersSelector_MouseLeave(object sender, MouseEventArgs e)
        {
            TranslateTransform translate = new TranslateTransform();
            translate.X = -230;

            FoldersSelector.RenderTransform = translate;
        }

        private void HomeButton_Loaded(object sender, RoutedEventArgs e)
        {

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

        private void FoldersSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = FoldersSelector.SelectedIndex;
            e.Handled = true;
            if (index == -1)
            {
                FoldersSelector.SelectedIndex = 0;
                index = 0;
            }
            else
            {
                data.Clear();
                data.Add(FolderData[index].Images);
                Scroller.Thumbnails.SelectedIndex = 1;
            }
            if (index != 0)
            {
                PictureFolderData selected = FolderData[index];
                FolderData.RemoveAt(index);
                FolderData.Insert(0, selected);
                FoldersSelector.SelectedIndex = 0;
            }

            if (FoldersSelector.Items.Count > 0)
                FoldersSelector.ScrollIntoView(FoldersSelector.Items[0]);
            
        }

    }
}
