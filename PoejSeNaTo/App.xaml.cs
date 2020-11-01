using System;
using PoejSeNaTo.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PoejSeNaTo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Notes.Init("db.sqlite");
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
