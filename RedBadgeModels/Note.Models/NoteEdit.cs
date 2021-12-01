using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeModels.Note.Models
{
    public class NoteEdit
    {
        public int NoteId { get; set; }
        public int TaskId { get; set; }
        public string Comment { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
