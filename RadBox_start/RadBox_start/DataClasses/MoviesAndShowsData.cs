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
    public class MoviesAndShowsData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public enum MovieType
        {
            Action,
            Cartoons,
            Singalong,
            All
        }

        List<string> moviesAction, moviesCartoons, moviesSingalong;

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
            moviesCartoons = new List<string>();
            moviesAction = new List<string>();
            moviesSingalong = new List<string>();


            moviesCartoons.Add( @"Assets\Videos\bunny.mp4");
            moviesAction.Add(@"Assets\Videos\lego.mp4");
            moviesSingalong.Add(@"Assets\Videos\letitgo.mp4");

            CurrentlyPlaying = @"Assets\Videos\lego.mp4";

        }

        // The index is based on 
        public void SetCurrentlyPlaying(int index, MovieType type)
        {
            switch(type)
            {
                case MovieType.All:
                    if (index < moviesAction.Count)
                        CurrentlyPlaying = moviesAction[index];
                    else if (index - moviesAction.Count < moviesCartoons.Count)
                        CurrentlyPlaying = moviesCartoons[index - moviesAction.Count];
                    else
                        CurrentlyPlaying = moviesSingalong[index - moviesAction.Count - moviesCartoons.Count];
                    break;
                case MovieType.Action:
                    CurrentlyPlaying = moviesAction[index];
                    break;
                case MovieType.Cartoons:
                    CurrentlyPlaying = moviesCartoons[index];
                    break;
                case MovieType.Singalong:
                    CurrentlyPlaying = moviesSingalong[index];
                    break;
            }

        }
    }
}
