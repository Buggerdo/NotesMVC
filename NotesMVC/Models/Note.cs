using System;
using System.Collections.Generic;

namespace NotesMVC.Models
{
    public partial class Note
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime Timestamp { get; set; }
    }
}
