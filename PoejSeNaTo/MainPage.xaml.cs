using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoejSeNaTo.Model;
using PoejSeNaTo.Page;
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

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task<List<Note>> allNotes = Notes.FindAll();
            allNotes.Wait();
            notesList.ItemsSource = allNotes.Result.OrderBy(v => v.ModifiedAt).ToList();
        }

        void notesList_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            Navigation.PushAsync(new EditPage((Note)e.SelectedItem));
        }
    }
}
