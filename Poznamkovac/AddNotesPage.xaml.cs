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

        public static List<Note> noteList;
        public static int notesCount;
        public static string ID;

        public AddNotesPage(string ID, List<Note> _noteList) {

            InitializeComponent();

            noteList = _noteList;
            notesCount = noteList.Count;

            if (ID != null) {
                Note note = noteList[int.Parse(ID)];
                NoteLabel.Text = note.Label;
                NoteText.Text = note.Text;
            }
        }

        public void ProcessNote(object sender, EventArgs args) {

            Note note = new Note {
                Label = NoteLabel.Text.ToString(),
                Text = NoteText.Text.ToString(),
                Date = DateTime.UtcNow
            };

            if (ID != null) {
                note.ID = int.Parse(ID);
            } else {
                note.ID = -69;
            }

            SaveNote(note, notesCount);
            Navigation.PopAsync();
        }

        protected async void SaveNote(Note note, int notesCount) {
            await App.Database.SaveNoteAsync(note, notesCount);
        }
    }
}