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

namespace RadBox_start.UserControls
{
    /// <summary>
    /// Interaction logic for ThumbnailScroller.xaml
    /// </summary>
    public partial class ThumbnailScroller : UserControl
    {
        public event RoutedEventHandler RightArrowClick, LeftArrowClick;
        public event SelectionChangedEventHandler SelectionChanged;

        public ThumbnailScroller()
        {
            InitializeComponent();
        }

        protected void Thumbnails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.SelectionChanged != null)
                SelectionChanged(this, e);
        }

        protected void LeftArrow_Click(object sender, RoutedEventArgs e)
        {
            if (this.LeftArrowClick != null)
                LeftArrowClick(this, e);
        }

        protected void RightArrow_Click(object sender, RoutedEventArgs e)
        {
            if (this.RightArrowClick != null)
                RightArrowClick(this, e);
        }
    }
}
