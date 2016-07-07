using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;

namespace Test.Models
{
    public class PhotoItem : PropertyChangedBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyOfPropertyChange(() => Name);
                }
            }
        }

        private string _imgPath;
        public string ImgPath
        {
            get { return _imgPath; }
            set
            {
                if (value != _imgPath)
                {
                    _imgPath = value;
                    NotifyOfPropertyChange(() => ImgPath);
                }
            }
        }

        private bool _showSelected;
        public bool ShowSelected
        {
            get { return _showSelected; }
            set
            {
                if (value != _showSelected)
                {
                    _showSelected = value;
                    NotifyOfPropertyChange(() => ShowSelected);
                }
            }
        }
    }
}
