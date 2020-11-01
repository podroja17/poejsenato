using System;
using System.Collections.Generic;
using PoejSeNaTo.Model;
using Xamarin.Forms;

namespace PoejSeNaTo.Page
{
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            String title = NoteTitle.Text;
            String content = Content.Text;

            if (String.IsNullOrWhiteSpace(title))
            {
                await DisplayAlert("Chyba", "Název poznámky nemůže být prázdný!", "OK");
                return;
            }

            if (String.IsNullOrWhiteSpace(content))
            {
                await DisplayAlert("Chyba", "Obsah poznámky nemůže být prázdný!", "OK");
                return;
            }

            this.SaveNote(title, content);
        }

        async private void SaveNote(String title, String content)
        {
            Note note = new Note();
            note.Id = 0;
            note.Title = title;
            note.Content = content;
            note.CreatedAt = DateTime.Now;
            note.ModifiedAt = DateTime.Now;
            await Notes.Store(note);
            await Navigation.PopAsync();
        }
    }
}
