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
    public partial class AddNotesPage : ContentPage {

        public static int id;

        public AddNotesPage(int _id = -1) {
            InitializeComponent();

            id = _id;

        }

        public void ProcessNote(object sender, EventArgs args) {

            

            Note note = new Note {
                Label = NoteLabel.Text.ToString(),
                Text = NoteText.Text.ToString(),
                Date = DateTime.UtcNow
            };

            if (id != -1)
                note.ID = id;

            SaveNote(note);
            Navigation.PopAsync();
        }

        protected async void SaveNote(Note note) {
            await App.Database.SaveNoteAsync(note);
        }
    }
}