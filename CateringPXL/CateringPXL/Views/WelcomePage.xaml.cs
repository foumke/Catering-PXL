using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Newtonsoft.Json;
using CateringPXL.Helpers;
using System.Diagnostics;

namespace CateringPXL
{
    public partial class WelcomePage : ContentPage
    {
        Splash splash;
        public WelcomePage(Splash splash)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.splash = splash;
        }

        public async void show_menu(string location)
        {
            Settings.CampusKeuze = location.ToUpper();
            splash.Get_data(Settings.CampusKeuze, false);
        }

        public void btnLocationElfdelinie_clicked(object sender, EventArgs args)
        {
            show_menu(((Button)sender).Text);
        }
        public void btnLocationDiepenbeek_clicked(object sender, EventArgs args)
        {
            show_menu(((Button)sender).Text);
        }
        public void btnLocationVilderstraat_clicked(object sender, EventArgs arg)
        {
            show_menu(((Button)sender).Text);
        }
    }
}
