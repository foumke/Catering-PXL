using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CateringPXL
{
    public partial class CardWrap : ContentView
    {
        string title;
        string content;

        public CardWrap(string title, string content)
        {
            InitializeComponent();

            lblTitle.Text = title;
            lblContent.Text = content;
        }
    }
}
