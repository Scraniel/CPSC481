using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadBox_start.DataClasses
{
    class PicturesData
    {
        public ObservableCollection<string> Images {get; set;}

        public PicturesData()
        {       
            Images = new ObservableCollection<string>();
            Images.Add("/RadBox_start;component/Assets/Images/MoviesAndShows/thumbnailFiller.png");
            Images.Add("/RadBox_start;component/Assets/Images/MoviesAndShows/videoFiller.png");
            Images.Add("/RadBox_start;component/Assets/Images/MoviesAndShows/thumbnailFiller.png");
            Images.Add("/RadBox_start;component/Assets/Images/MoviesAndShows/thumbnailFiller.png");
            Images.Add("/RadBox_start;component/Assets/Images/MoviesAndShows/videoFiller.png");
            Images.Add("/RadBox_start;component/Assets/Images/MoviesAndShows/thumbnailFiller.png");
        }


    }
}
