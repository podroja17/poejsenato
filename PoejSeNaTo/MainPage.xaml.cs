using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PoejSeNaTo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                this.Padding = new Thickness(0, 20, 0, 0);
            }
            InitializeComponent();
        }
    }
}
