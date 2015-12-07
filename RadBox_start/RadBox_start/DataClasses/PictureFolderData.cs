using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadBox_start.DataClasses
{
    public class PictureFolderData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        List<string> _images;
        string _thumbnail;
        string _title;

        public List<string> Images
        {
            get{ return _images; }
            set
            {
                _images = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Images"));
            }
        }
        public string Thumbnail 
        { 
            get { return _thumbnail; } 
            set
            {
                _thumbnail = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Thumbnail"));
            }
        }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Title"));
            }
        }
        
        public PictureFolderData(string thumbnail, string title, List<string> images)
        {
            Thumbnail = thumbnail;
            Title = title;
            Images = images;
        }

        public void Add(List<string> newImages)
        {
            foreach(string s in newImages)
                Images.Add(s);
        }
    }
}
