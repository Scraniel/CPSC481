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
    /// Interaction logic for PicturesPage.xaml
    /// </summary>
    public partial class PicturesPage : Page
    {
        PicturesData data = new PicturesData();
        public PicturesPage()
        {
            InitializeComponent(); 
            DataContext = data;
            Thumbnails.SelectedIndex = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigator.LandingPage(); 
        }

        private void photoPlay(object sender, RoutedEventArgs e)
        {
            Navigator.PictureFullScreen();
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
            /*
            int index = Utility.IndexWrapAround(Thumbnails.SelectedIndex + 1, Thumbnails.Items.Count);
            Thumbnails.SelectedIndex = index;
            */
            data.ShiftRight();
            Thumbnails.SelectedIndex = 1;
        }

        private void LeftArrow_Click(object sender, RoutedEventArgs e)
        {
            /*
            int index = Utility.IndexWrapAround(Thumbnails.SelectedIndex - 1, Thumbnails.Items.Count);
            Thumbnails.SelectedIndex = index;
             */
            data.ShiftLeft();
            Thumbnails.SelectedIndex = 1;
        }

        private void Thumbnails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = Thumbnails.SelectedIndex;
            e.Handled = true;
            if (index == -1)
                Thumbnails.SelectedIndex = 1;

            if (index == PicturesData.BEGINNING)
                LeftArrow_Click(LeftArrow, new RoutedEventArgs());
            else if (index == PicturesData.END)
                RightArrow_Click(RightArrow, new RoutedEventArgs());
            

            data.CurrentlySelected = data.Images[Thumbnails.SelectedIndex];
        }

    }
}
