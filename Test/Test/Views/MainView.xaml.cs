using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using Caliburn.Micro.Xamarin.Forms;

namespace Test.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {

            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();                                                               
    }

}
}