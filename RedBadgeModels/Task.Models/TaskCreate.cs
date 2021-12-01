using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeModels.Task.Models
{
    public class TaskCreate
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
