using CateringPXL.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CateringPXL
{
    public partial class MenuPage : CarouselPage
    {
        public MenuPage(Splash splash)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetTitleIcon(this, null);

            //Navigation.PopToRootAsync();
            try
            {
                Navigation.InsertPageBefore(new WelcomePage(splash), this);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("JAN " + ex.ToString());
            }

            CheckLogin();
        }
        public async void CheckLogin()
        {
            if (Settings.FirstLogin.Equals(string.Empty))
            {
                await DisplayAlert("Welkom", "Hier volgen enkele instructies \n \n 1) Swipe voor het wisselen van dagen \n \n 2) Klik op het logo voor het wisselen van campus \n \n Eet smakelijk!", "Oke");
                Settings.FirstLogin = "1";
            }

        }



    }
}
