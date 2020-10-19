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

        public static int ID;

        public AddNotesPage(int id = -1) {
            InitializeComponent();

            ID = id;

        }

        public void ProcessNote(object sender, EventArgs args) {
            // new note
            if (ID == -1) {
                Note note = new Note {
                    Label = NoteLabel.Text.ToString(),
                    Text = NoteText.Text.ToString(),
                    Date = DateTime.UtcNow
                };

                SaveNote(note);
                Navigation.PopAsync();

            } else {
                // edit note
            }
        }

        protected async void SaveNote(Note note) {
            await App.Database.SaveNoteAsync(note);
        }

    }
}