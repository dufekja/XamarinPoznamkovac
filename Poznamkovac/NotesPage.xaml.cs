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

        public static List<Note> notesList;

        public NotesPage() {
            InitializeComponent();

            LoadDB();
        }

        /** Event methods */

        public void OnAddNote(object sender, EventArgs args) {
            Navigation.PushAsync(new AddNotesPage(null, notesList));
        }

        public void OnRewriteNote(object sender, EventArgs args) {

            Button clickedButton = (Button)sender;
            string ID = clickedButton.ClassId.ToString();

            Navigation.PushAsync(new AddNotesPage(ID, notesList));
        }

        public void OnDeleteNote(object sender, EventArgs args) {

            Button clickedButton = (Button)sender;
            string ID = clickedButton.ClassId.ToString();

            DeleteNote(int.Parse(ID));
            LoadDB();
        }

        /** Async Tasks */
        
        protected async void DeleteNote(int ID) {
            Note note = await App.Database.GetNoteAsync(ID);
            await App.Database.DeleteNoteAsync(note);

            NotesView.ItemsSource = null;
            NotesView.ItemsSource = notesList;
        }

        protected async void LoadDB() {
            notesList = await App.Database.GetNotesAsync();
            NotesView.ItemsSource = notesList;
        }

    }

}