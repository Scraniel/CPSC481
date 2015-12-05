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
        private List<string> _allImages;
        private int _currentStart;
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
            _allImages.Add("/RadBox_start;component/Assets/Images/Pictures/1.png");
            _allImages.Add("/RadBox_start;component/Assets/Images/Pictures/2.png");
            _allImages.Add("/RadBox_start;component/Assets/Images/Pictures/3.png");
            _allImages.Add("/RadBox_start;component/Assets/Images/Pictures/4.png");
            _allImages.Add("/RadBox_start;component/Assets/Images/Pictures/5.png");
            _allImages.Add("/RadBox_start;component/Assets/Images/Pictures/6.png");

            Images.Add("/RadBox_start;component/Assets/Images/Pictures/1.png");
            Images.Add("/RadBox_start;component/Assets/Images/Pictures/2.png");
            Images.Add("/RadBox_start;component/Assets/Images/Pictures/3.png");
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
    }
}
