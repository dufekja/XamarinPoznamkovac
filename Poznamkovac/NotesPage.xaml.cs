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

            Note note = new Note {
                Label = "label2",
                Text = "djwqi",
                Date = DateTime.UtcNow
            };

            //SaveNote(note);
            
        }
       
        public void AddNotesPage(object sender, EventArgs args) {
            Navigation.PushAsync(new AddNotesPage());
        }

        protected async void SaveNote(Note note) {
            await App.Database.SaveNoteAsync(note);
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