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
            Scroller.Thumbnails.SelectedIndex = 1;

            Scroller.RightArrowClick += new RoutedEventHandler(RightArrow_Click);
            Scroller.LeftArrowClick += new RoutedEventHandler(LeftArrow_Click);
            Scroller.SelectionChanged += new SelectionChangedEventHandler(Thumbnails_SelectionChanged);

            data.Add("/RadBox_start;component/Assets/Images/Pictures/1.png");
            data.Add("/RadBox_start;component/Assets/Images/Pictures/2.png");
            data.Add("/RadBox_start;component/Assets/Images/Pictures/3.png");
            data.Add("/RadBox_start;component/Assets/Images/Pictures/4.png");
            data.Add("/RadBox_start;component/Assets/Images/Pictures/5.png");
            data.Add("/RadBox_start;component/Assets/Images/Pictures/6.png");

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
                Scroller.Thumbnails.SelectedIndex = 1;

            if (index == PicturesData.BEGINNING)
                LeftArrow_Click(Scroller.LeftArrow, new RoutedEventArgs());
            else if (index == PicturesData.END)
                RightArrow_Click(Scroller.RightArrow, new RoutedEventArgs());


            data.CurrentlySelected = data.Images[Scroller.Thumbnails.SelectedIndex];
        }

    }
}
