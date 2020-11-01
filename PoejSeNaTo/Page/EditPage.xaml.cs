using System;
using System.Collections.Generic;
using PoejSeNaTo.Model;
using Xamarin.Forms;

namespace PoejSeNaTo.Page
{
    public partial class EditPage : ContentPage
    {
        private Note note;

        public EditPage(Note note)
        {
            this.note = note;
            InitializeComponent();
            NoteTitle.Text = note.Title;
            Content.Text = note.Content;
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

            bool update = title != this.note.Title || content != this.note.Content;

            if (!update)
            {
                await Navigation.PopAsync();
            }

            this.note.ModifiedAt = DateTime.Now;
            this.note.Content = content;
            this.note.Title = title;
            await Notes.Store(this.note);
            await Navigation.PopAsync();
        }

        async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            bool reallyDelete = await DisplayAlert("?", "Chcete opravdu smazat tuto poznámku?", "Ano", "Ne");

            if (reallyDelete)
            {
                await Notes.Delete(this.note);
                await Navigation.PopAsync();
            }
        }
    }
}
