using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeModels.Project.Models
{
    public class ProjectEdit
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
