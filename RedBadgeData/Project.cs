using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeData
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        
        [Required]
        public Guid UserId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
