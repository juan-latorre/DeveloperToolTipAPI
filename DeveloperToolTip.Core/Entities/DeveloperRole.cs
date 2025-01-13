using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperToolTip.Core.Entities
{
    [Table("DeveloperRole")]
    public class DeveloperRole
    {
        [Key]
        public int Id { get; set; }
        public required string RoleName { get; set; }
    }
}
