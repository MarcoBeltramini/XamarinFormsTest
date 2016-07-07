using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Caliburn.Micro.Xamarin.Forms;
using System.Threading;
using System.Diagnostics;
using Newtonsoft.Json;
using Caliburn.Micro;

using Test.Models;

namespace Test.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;       

        public const double MIN_TEMPERATURE = 2;
        public const double MAX_TEMPERATURE = 40;                

        #region Properties

        private BindableCollection<HouseListItem> _houses;
        public BindableCollection<HouseListItem> Houses
        {
            get { return _houses; }
            set
            {
                if (value != _houses)
                {
                    _houses = value;
                    NotifyOfPropertyChange(() => Houses);
                }
            }
        }
      
        private double _manuOverlayTemperature;
        public double ManuOverlayTemperature
        {
            get { return _manuOverlayTemperature; }
            set
            {
                if (value != _manuOverlayTemperature)
                {
                    _manuOverlayTemperature = value;
                    NotifyOfPropertyChange(() => ManuOverlayTemperature);
                }
            }
        }       

        #endregion

        #region Boolean                

        private bool _showManuOverlay;
        public bool ShowManuOverlay
        {
            get { return _showManuOverlay; }
            set
            {
                if (value != _showManuOverlay)
                {
                    _showManuOverlay = value;
                   
                    NotifyOfPropertyChange(() => ShowManuOverlay);
                }
            }
        }

        private bool _editManuMode;
        public bool EditManuMode
        {
            get { return _editManuMode; }
            set
            {
                if (value != _editManuMode)
                {
                    _editManuMode = value;
                    NotifyOfPropertyChange(() => EditManuMode);
                }
            }
        }

        #endregion

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            #region Add Fake Items
            var rooms = new BindableCollection<Room>();
            Houses = new BindableCollection<HouseListItem>();
            rooms.Add(new Room { Name = "Cucina", Photo = new PhotoItem { ImgPath = "Test.Assets.bedroom.jpg" }, CurrentTemperature = 19.6, CurrentMode = Modes.AUTO, DesiredTemperature = 19.5 });

            var rooms2 = new BindableCollection<Room>();
            rooms2.Add(new Room { Name = " Camera vasca", Photo = new PhotoItem { ImgPath = "Test.Assets.livingroom2.jpg" }, CurrentTemperature = 20.8, CurrentMode = Modes.JLLY, DesiredTemperature = 21, ShowFlame = true, SelectedSeason = Season.Estate });
            rooms2.Add(new Room { Name = "Camera Leo", Photo = new PhotoItem { ImgPath = "Test.Assets.bedroom.jpg" }, CurrentTemperature = 20.8, CurrentMode = Modes.MANU, DesiredTemperature = 21, ShowFlame = true });       

            Houses.Add(new HouseListItem { Name = "Casa Milano", Rooms = rooms });
            Houses.Add(new HouseListItem { Name = "Casa Mare", Rooms = rooms2 });            
            #endregion                     

            

        }                     

        protected override void OnActivate()
        {
            base.OnActivate();              
            ShowManuOverlay = false;
            _getCrono();
        }                

        private async void _getCrono()
        {
            var containsSerial = true;

            if (containsSerial)
            {
                try
                {
                    var client = new HttpClient();
                    string s = "http://fantinicosmi.cloudapp.net/api/Cronos/00000448" ;
                    var request = new HttpRequestMessage
                    {
                        Method = new HttpMethod("GET"),
                        RequestUri = new Uri(s)
                    };                   
                    var response = await (await client.SendAsync(request)).Content.ReadAsStringAsync();
                    var jsonObject = JsonConvert.DeserializeObject<RawResponse>(response, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore });
                    var mode = (Modes)int.Parse(jsonObject.Mode);
                    var season = (Season)int.Parse(jsonObject.WS);
                    float temp;
                    float desiredTemp = 0;                   
                    switch (mode)
                    {
                        case Modes.MANU:
                            desiredTemp = jsonObject.TMan;
                            break;
                        case Modes.AUTO:
                            temp = jsonObject.TAmb;
                            break;
                        case Modes.HDAY:
                            temp = jsonObject.TAmb;
                            break;
                        case Modes.JLLY:
                            if (jsonObject.TJ != null)
                            {
                                desiredTemp = float.Parse(jsonObject.TJ.ToString());                               
                            }
                            break;
                        case Modes.OFF:
                            break;
                        default:
                            desiredTemp = jsonObject.TMan;
                            break;
                    }
                    App.T1 = jsonObject.T1;
                    App.T2 = jsonObject.T2;
                    App.T3 = jsonObject.T3;                   
                    App.TAFrost = (float)jsonObject.Tafrost;                 

                    Houses[0].Rooms[0] = new Room { Name = jsonObject.Name, SelectedSeason = season,                     
                        Photo = new PhotoItem { ImgPath = (string)jsonObject.Image }, CurrentTemperature = jsonObject.TAmb, CurrentMode = mode, DesiredTemperature = desiredTemp, ShowFlame = jsonObject.Relay };
                    Houses[0].SelectedRoom = Houses[0].Rooms[0];
                }
                catch
                {
          
                }
            }
        }              

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            _getCrono();
        }             

        #region Manual Mode
        public void Manual()
        {           
            ShowManuOverlay = true;           
        }

        public void ConfirmManuMode()
        {                    
            ShowManuOverlay = false;
        }             

        public void IncreaseManuTemperature()
        {
            if (ManuOverlayTemperature < MAX_TEMPERATURE)
            {
                ManuOverlayTemperature += 0.1;
            }
        }       

        public void DecreaseManuTemperature()
        {
            if (ManuOverlayTemperature > MIN_TEMPERATURE)
            {
                ManuOverlayTemperature -= 0.1;
            }
        }

        public void EditManuTemperature()
        {
            EditManuMode = true;

        }
        #endregion         
                
                  
        private void _closeAllCards()
        {
            foreach (var item in Houses)
            {
                item.IsOpen = false;
            }
        }
       
    }
}

