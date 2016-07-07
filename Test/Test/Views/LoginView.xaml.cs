using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Test.Views
{
    public partial class LoginView : ContentPage
	{
		public LoginView ()
		{
            InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);

            Resources = App.Current.Resources;
		}

    }
}
