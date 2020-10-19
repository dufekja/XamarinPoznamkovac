using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poznamkovac.Database {
    public class Note {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Label { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
