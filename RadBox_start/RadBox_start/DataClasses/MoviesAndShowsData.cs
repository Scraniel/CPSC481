using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RadBox_start.DataClasses
{
    class MoviesAndShowsData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        List<string> currentlyShown, moviesAction, moviesCartoons, moviesSingalong;

        string _currentlyPlaying;
        public string CurrentlyPlaying
        {
            get { return _currentlyPlaying; }
            set
            {
                _currentlyPlaying = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentlyPlaying"));
            }
        }

        public MoviesAndShowsData()
        {
            CurrentlyPlaying = "../Assets/Videos/SampleVideo_1080x720_1mb.mp4";
        }
    }
}
