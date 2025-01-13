using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperToolTip.Application.DTOs.DeveloperDTOs
{
    public class UpdateDeveloperDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string Login { get; set; }
        public int RoleId { get; set; }
        public bool? IsActive { get; set; }
    }
}
