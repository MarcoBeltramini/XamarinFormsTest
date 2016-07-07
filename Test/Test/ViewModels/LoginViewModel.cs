using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Test.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly Caliburn.Micro.Xamarin.Forms.INavigationService _navigationService;

        #region Properties
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    NotifyOfPropertyChange(() => Username);
                }
            }
        }     
             
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    NotifyOfPropertyChange(() => Password);
                }
            }
        }               
        #endregion

        public LoginViewModel(Caliburn.Micro.Xamarin.Forms.INavigationService navigationService)
        {
            _navigationService = navigationService;          
        }

        public void Login()
        {                                       
             Execute.OnUIThread(()=> {
                _navigationService.For<MainViewModel>().Navigate();
            });                       
           
        }     

       
    }

}
