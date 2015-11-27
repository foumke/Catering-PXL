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
    public partial class MenuWrap : ContentPage
    {
        public string title;
        MenuPage carousel;
        Splash splash;
        public MenuWrap(DagMenu menu, MenuPage carousel, Splash splash)
        {
            InitializeComponent();
            this.splash = splash;
            //lbl_datum.VerticalOptions

            Logo_Click();
            this.carousel = carousel;
            laadMenu(menu);
        }
       public void  Logo_Click()
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (sender, e) => Navigation.PushAsync(new WelcomePage(splash));
            image.GestureRecognizers.Add(tapGestureRecognizer);
        }
      
        public void laadMenu(DagMenu menu)
        {
            if (menu != null)
            {
                lbl_locatie.Text = menu.Title;
                lbl_datum.Text = menu.Datum;

                cardView.Children.Add(new CardWrap("Voorgerecht", menu.VoorGerecht));
                cardView.Children.Add(new CardWrap("Hoofdgerecht", menu.HoofdGerecht));
                cardView.Children.Add(new CardWrap("Nagerecht", menu.NaGerecht));
                cardView.Children.Add(new CardWrap("Soep van de week", menu.WeekSoep));
                cardView.Children.Add(new CardWrap("Maaltijd soep en brood", menu.MaaltijdSoepEnBrood));
                cardView.Children.Add(new CardWrap("Veggie", menu.Veggie));
                cardView.Children.Add(new CardWrap("Aanrader", menu.Aanrader));
                cardView.Children.Add(new CardWrap("Pasta van de dag", menu.PastaVanDeDag));
                cardView.Children.Add(new CardWrap("Suggestie", menu.Suggestie));
                cardView.Children.Add(new CardWrap("Healthfood", menu.HealthFood));
                cardView.Children.Add(new CardWrap("Snack van de dag", menu.SnackVanDeDag));
            }

        }
      

    }
}
