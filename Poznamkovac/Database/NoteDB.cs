using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Poznamkovac.Database {
    public class NoteDB {
        readonly SQLiteAsyncConnection _DB;

        public NoteDB(string dbPath) {
            _DB = new SQLiteAsyncConnection(dbPath);
            _DB.CreateTableAsync<Note>().Wait();
        }

        public Task<List<Note>> GetNotesAsync() {
            return _DB.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNoteAsync(int id) {
            return _DB.Table<Note>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Note note) {
            if (note.ID != -1) {
                return _DB.UpdateAsync(note);
            } else {
                return _DB.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Note note) {
            return _DB.DeleteAsync(note);
        }
    }
}
