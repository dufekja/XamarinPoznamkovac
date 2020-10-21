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

        public static string ID;

        public AddNotesPage(string _ID) { 
            InitializeComponent();

            ID = _ID;

            if (ID != null) {
                LoadNote(int.Parse(ID));
            }
        }

        public void ProcessNote(object sender, EventArgs args) {

            if (ID != null) {
                EditNote(int.Parse(ID), NoteLabel.Text.ToString(), NoteText.Text.ToString());
               
            } else {
                DateTime date = DateTime.UtcNow;
                Note note = new Note {
                    Label = NoteLabel.Text.ToString(),
                    Text = NoteText.Text.ToString(),
                    CreationDate = date,
                    Date = date
                };
                SaveNote(note);
            }
            Navigation.PopAsync();
            Navigation.InsertPageBefore(new NotesPage(), this);
            Navigation.PopAsync();
        }

        private async void EditNote(int id, string label, string text) {
            await App.Database.EditNoteAsync(id, label, text);
        }

        private async void LoadNote(int id) {
            Note note = await App.Database.GetNoteAsync(id);
            NoteLabel.Text = note.Label.ToString();
            NoteText.Text = note.Text.ToString();
        }

        private async void SaveNote(Note note) {
            int Savedrows = await App.Database.SaveNoteAsync(note);
        }

    }
}