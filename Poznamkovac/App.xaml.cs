using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Poznamkovac {
    public partial class App : Application {

        static Database.NoteDB database;
        public static Database.NoteDB Database {
            get {
                if (database == null) {
                    database = new Database.NoteDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }

        public App() {
            InitializeComponent();

            MainPage = new NavigationPage(new NotesPage());

        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
