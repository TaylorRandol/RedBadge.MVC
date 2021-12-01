using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeData
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        
        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [DefaultValue(false)]
        public bool IsDone { get; set; }
        
        /*public DateTime DueDate { get; set; }*/
    }
}
