using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperToolTip.Core.Entities
{
    [Table("DeveloperLogin")]
    public class DeveloperLogin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DeveloperId { get; set; }

        [ForeignKey("DeveloperId")]
        public virtual Developer Developer { get; set; }

        [Required]
        public DateTime LoginDate { get; set; } = DateTime.UtcNow;

        public string? IpAddress { get; set; }

        [Required]
        public bool IsActive { get; set; } = true; 

    }
}
