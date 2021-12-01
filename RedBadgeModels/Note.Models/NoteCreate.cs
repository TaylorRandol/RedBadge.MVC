using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeModels.Note.Models
{
    public class NoteCreate
    {
        public int TaskId { get; set; }
        public string Comment { get; set; }
    }
}
