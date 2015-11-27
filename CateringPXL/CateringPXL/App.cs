using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace CateringPXL
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            NavigationPage test = new NavigationPage(new Splash());
            MainPage = test;
           
            test.BarBackgroundColor = Colors.PXL_groen;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        { 
        }
    }
}
