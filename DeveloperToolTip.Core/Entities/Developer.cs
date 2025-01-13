using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperToolTip.Core.Entities
{
    [Table("Developer")]
    public class Developer
    {
        [Key]
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Email { get; set; }
        public string? Login { get; set; }
        public required string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey("RoleId")]

        public virtual DeveloperRole? Role { get; set; }
        
    }
}
