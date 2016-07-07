using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Caliburn.Micro;
namespace Test.Models
{
    class DisplayAttribute : Attribute
    {
        internal DisplayAttribute(string imgPath)
        {
            this.ImgPath = imgPath;
        }
        public string ImgPath { get; private set; }

    }

    public enum Season
    {
        [Display("Intelliclima.Assets.flame.png")]
        Inverno,
        [Display("Intelliclima.Assets.Winter.png")]
        Estate
    }

    public enum Modes
    {
        MANU,
        AUTO,
        HDAY,
        JLLY,
        OFF
    }

    public class HouseListItem : PropertyChangedBase
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

        private Modes _currentMode;
        public Modes CurrentMode
        {
            get { return _currentMode; }
            set
            {
                if (value != _currentMode)
                {
                    _currentMode = value;
                    NotifyOfPropertyChange(() => CurrentMode);
                }
            }
        }

        private bool _isOpen;
        public bool IsOpen
        {
            get { return _isOpen; }
            set
            {
                if (value != _isOpen)
                {
                    _isOpen = value;
                    NotifyOfPropertyChange(() => IsOpen);
                }
            }
        }
              

        private BindableCollection<Room> _rooms;
        public BindableCollection<Room> Rooms
        {
            get { return _rooms; }
            set
            {
                if (value != _rooms)
                {
                    _rooms = value;
                    NotifyOfPropertyChange(() => Rooms);
                }
            }
        }

        private Room _selectedRoom;
        public Room SelectedRoom
        {
            get
            {
                if (_selectedRoom == null)
                {
                    if (_rooms != null && _rooms.Count > 0)
                    {                       
                        return null;
                    }
                    else
                    {                       
                        return new Room();
                    }
                }
                else
                {
                    return _selectedRoom;
                }
            }
            set
            {
                if (value != _selectedRoom)
                {
                    _selectedRoom = value;
                    if (value != null)
                    {
                        CurrentMode = value.CurrentMode;
                    }
                    NotifyOfPropertyChange(() => SelectedRoom);
                }
            }
        }
    }

    public class Room : PropertyChangedBase
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

        private Modes _currentMode;
        public Modes CurrentMode
        {
            get { return _currentMode; }
            set
            {
                if (value != _currentMode)
                {
                    _currentMode = value;
                    NotifyOfPropertyChange(() => CurrentMode);
                }
            }
        }

        private bool _showFlame;
        public bool ShowFlame
        {
            get { return _showFlame; }
            set
            {
                if (value != _showFlame)
                {
                    _showFlame = value;
                    NotifyOfPropertyChange(() => ShowFlame);
                }
            }
        }

        private double _currentTemperature;
        public double CurrentTemperature
        {
            get { return _currentTemperature; }
            set
            {
                if (value != _currentTemperature)
                {
                    _currentTemperature = value;
                    NotifyOfPropertyChange(() => CurrentTemperature);
                }
            }
        }
               
        private double _desiredTemperature;
        public double DesiredTemperature
        {
            get { return _desiredTemperature; }
            set
            {
                if (value != _desiredTemperature)
                {
                    _desiredTemperature = value;
                    NotifyOfPropertyChange(() => DesiredTemperature);
                }
            }
        }

        private Season _selectedSeason;
        public Season SelectedSeason
        {
            get { return _selectedSeason; }
            set
            {
                if (value != _selectedSeason)
                {
                    _selectedSeason = value;
                    NotifyOfPropertyChange(() => SelectedSeason);
                }
            }
        }       
       
        private PhotoItem _photo;
        public PhotoItem Photo
        {
            get { return _photo; }
            set
            {
                if (value != _photo)
                {
                    _photo = value;
                    NotifyOfPropertyChange(() => Photo);
                }
            }
        }       
              

    }
}
