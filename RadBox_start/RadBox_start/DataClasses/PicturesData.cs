using RadBox_start.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadBox_start.DataClasses
{
    public class PicturesData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Should always be 3 elements
        public List<string> _allImages;
        public int _currentStart;
        public static int MAX_SHOWN = 3;
        public static int BEGINNING = 0;
        public static int END = MAX_SHOWN - 1;
        public ObservableCollection<string> Images {get; set;}

        private string _currentlySelected;
        public string CurrentlySelected
        {
            get { return _currentlySelected; }
            set
            {
                _currentlySelected = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentlySelected"));
            }
        }

        public PicturesData()
        {       
            Images = new ObservableCollection<string>();
            _allImages = new List<string>();
            _currentStart = 0;
        }

        public void ShiftRight()
        {
            Images.RemoveAt(BEGINNING);
            _currentStart = Utility.IndexWrapAround(_currentStart + 1, _allImages.Count);
            int index = Utility.IndexWrapAround(_currentStart + MAX_SHOWN - 1, _allImages.Count);
            Images.Add(_allImages[index]);
        }

        public void ShiftLeft()
        {
            Images.RemoveAt(END);
            _currentStart = Utility.IndexWrapAround(_currentStart - 1, _allImages.Count);
            Images.Insert(0,_allImages[_currentStart]);
        }

        public void Add(string newPhoto)
        {
            if(Images.Count < MAX_SHOWN)
            {
                Images.Add(newPhoto);
            }

            _allImages.Add(newPhoto);
        }

        public void Add(List<string> newPhotos)
        {
            foreach(string s in newPhotos)
                Add(s);
        }

        public void Add(List<MoviesMetadata> newPhotosFromMetaData)
        {
            foreach(MoviesMetadata m in newPhotosFromMetaData)
                Add(m.Path);
        }

        public void Update(string oldPath, string newPath)
        {
            int index = _allImages.IndexOf(oldPath);
            _allImages.RemoveAt(index);
            _allImages.Insert(index, newPath);

            index = Images.IndexOf(oldPath);
            if(index >= 0)
            {
                Images.RemoveAt(index);
                Images.Insert(index, newPath);
            }
            if (CurrentlySelected == oldPath)
                CurrentlySelected = newPath;


        }

        public void Clear()
        {
            _currentStart = 0;
            Images.Clear();
            _allImages.Clear();
        }
    }
}
