using Poznamkovac.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Poznamkovac {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage {

        public NotesPage() {
            InitializeComponent();  
        }

        protected override async void OnAppearing() {
            base.OnAppearing();

            NotesView.ItemsSource = await App.Database.GetNotesAsync();
        }

        public void OnAddNote(object sender, EventArgs args) {
            Navigation.PushAsync(new AddNotesPage(null));
        }

        public void OnRewriteNote(object sender, EventArgs args) {

            Button clickedButton = (Button)sender;
            string ID = clickedButton.ClassId.ToString();

            Navigation.PushAsync(new AddNotesPage(ID));
        }

        public async void OnDeleteNote(object sender, EventArgs args) {

            Button clickedButton = (Button)sender;
            string ID = clickedButton.ClassId.ToString();

            Note note = await App.Database.GetNoteAsync(int.Parse(ID));
            App.Database.DeleteNoteAsync(note);
            Refresh();

        }

        public void Refresh() {
            Navigation.InsertPageBefore(new NotesPage(), this);
            Navigation.PopAsync();
        }

    }

}