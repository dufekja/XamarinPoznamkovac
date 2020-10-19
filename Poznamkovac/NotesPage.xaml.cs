using Poznamkovac.Database;
using System;
using System.Collections.Generic;
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
       
        public void AddNotesPage(object sender, EventArgs args) {
            Navigation.PushAsync(new AddNotesPage());
        }

        public void EditNotesPage(object sender, EventArgs args) {
            Navigation.PushAsync(new AddNotesPage(1));
        }

        protected override async void OnAppearing() {
            base.OnAppearing();

            List<Note> notesList = await App.Database.GetNotesAsync();
            List<string> stringList = new List<string>();

            foreach (Note note in notesList) {
                stringList.Add($"{note.Label} - {note.Text}, {note.Date}");
            }

            NotesView.ItemsSource = notesList;

        }
    }

}