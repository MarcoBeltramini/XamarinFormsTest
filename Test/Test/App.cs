using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.ViewModels;
using Test.Views;
using Xamarin.Forms;

namespace Test
{
    public class App : FormsApplication
    {
        private readonly SimpleContainer container;

        public static float T1, T2, T3 = 0;

        public static float TAFrost;

        public App(SimpleContainer container)
        {
            this.container = container;

            container.PerRequest<LoginViewModel>();            
            container.PerRequest<MainViewModel>();

            var globalStyles = new Test.Utilities.GlobalStyle();
            Resources = globalStyles.Resources;

            DisplayRootView<LoginView>();
        }

        protected override void PrepareViewFirst(NavigationPage navigationPage)
        {
            container.Instance<INavigationService>(new NavigationPageAdapter(navigationPage));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
