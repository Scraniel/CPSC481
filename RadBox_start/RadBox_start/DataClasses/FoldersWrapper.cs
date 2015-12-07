using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadBox_start.DataClasses
{
    class FoldersWrapper : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        List<PictureFolderData> _folderData;
        public List<PictureFolderData> FolderData
        {
            get { return _folderData; }
            set
            {
                _folderData = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("FolderData"));
            }
        }

        public FoldersWrapper()
        {
            FolderData = new List<PictureFolderData>();
        }
        
    }
}
