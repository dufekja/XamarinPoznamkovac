using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Poznamkovac.Database {
    public class NoteDB {
        readonly SQLiteAsyncConnection _DB;

        public NoteDB(string dbPath) {
            _DB = new SQLiteAsyncConnection(dbPath);
            _DB.CreateTableAsync<Note>().Wait();
        }

        public async Task<List<Note>> GetNotesAsync() {
            return await _DB.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNoteAsync(int id) {
            return _DB.Table<Note>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> SaveNoteAsync(Note note) {
            int insertedRows = await _DB.InsertAsync(note);
            return insertedRows;
        }

        public async Task EditNoteAsync(int id, string label, string text) {
            Note note = await GetNoteAsync(id);

            note.Label = label;
            note.Text = text;
            note.Date = DateTime.UtcNow;
            await _DB.UpdateAsync(note);
        }

        public async void DeleteNoteAsync(Note note) {
            int deletedRows = await _DB.DeleteAsync(note);
        }
    }
}
