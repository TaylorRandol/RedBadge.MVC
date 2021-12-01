using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeModels.Note.Models
{
    public class NoteListItem
    {
        public int NoteId { get; set; }
        public int TaskId { get; set; }
        public string Comment { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
