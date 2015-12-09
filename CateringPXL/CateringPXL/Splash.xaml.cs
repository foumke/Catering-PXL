using CateringPXL.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CateringPXL
{
    public partial class Splash : ContentPage
    {

        public Splash()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            Handler();
        }

        public async void Handler()
        {
            /* Systeem datum opvragen zodat we de huidige dag weergeven */ 
            DateTime date = DateTime.Today;
            string strDate = String.Format("{0:yyyy-MM-dd}", date);
            /* Nakijken als er ooit een campus keuze is ingegeven */
            if (Settings.CampusKeuze.Equals(string.Empty))
            {
                await Navigation.PushAsync(new WelcomePage(this));
            }
            /* Nakijken als er vandaag al een server call gedaan is */
            else if (Settings.DatumVandaag.Equals(strDate))
            {
                Settings.menu = JsonConvert.DeserializeObject<DagMenu[]>(Settings.DagMenuJson);
                MaakCarousel(); 
            }
            /* Maak de call */
            else
            {
                Get_data(Settings.CampusKeuze);

            }
        } 

        public async void Get_data(string titel, Boolean push_welcome = true)
        {
            /* In deze methode wordt het menu ingelezen van de server en opgeslagen in Helpers/Settings */
            indicator.IsVisible = true;
            indicator.IsRunning = true;
            try
            {
                HttpClient client;
                client = new HttpClient();
                client.MaxResponseContentBufferSize = 256000;

                var RestUrl = "http://data.pxl.be/catering/" + titel + "/comingdays";
                var uri = new Uri(string.Format(RestUrl, string.Empty));

                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    content = System.Net.WebUtility.HtmlDecode(content);
                    Settings.DagMenuJson = content.ToString();
                    Settings.menu = JsonConvert.DeserializeObject<DagMenu[]>(Settings.DagMenuJson);
                    Settings.DatumVandaag = Settings.menu[0].Datum;
                    // Carousel maken 
                    MaakCarousel(push_welcome);
                }

            }
            catch (Exception e)
            {
                await DisplayAlert("Connectie fout", "Geen internet verbinding", "OK");
        
            }
            finally
            {
                indicator.IsVisible = false;
                indicator.IsRunning = false;
            }
        }

        public async void MaakCarousel(Boolean push_welcome = true)
        {
            /* self explanatory */ 
            var carouselPage = new MenuPage(this);
            int aantalChildren = Settings.menu.Count();

            for (int i = 0; i < aantalChildren; i++)
            {
                carouselPage.Children.Add(new MenuWrap(Settings.menu[i], carouselPage, this));
            }
            
            NavigationPage.SetHasBackButton(carouselPage, false);

            if(push_welcome)
            {
                await Navigation.PushAsync(new WelcomePage(this));
            }
            await Navigation.PushAsync(carouselPage);
        }
    }
}
