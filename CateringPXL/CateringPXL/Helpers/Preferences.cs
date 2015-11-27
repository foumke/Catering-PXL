using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringPXL
{
    class Preferences
    {
        public static string preferedLocation = "Elfdelinie";
        public static DagMenu[] menu;

        public static DagMenu getDagmenuOnLocation(String locatie)
        {
            for(int i = 0; i < menu.Length; i++)
            {
                if(locatie.Equals(menu[i].Locatie))
                {
                    return menu[i];
                }
            }

            return null;
        }
    }
}
