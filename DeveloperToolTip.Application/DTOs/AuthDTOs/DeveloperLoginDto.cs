using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperToolTip.Application.DTOs.AuthDTOs
{
    public class DeveloperLoginDto
    {
        public int DeveloperId { get; set; }
        public DateTime LoginDate { get; set; }
        public string IpAddress { get; set; }
        public bool IsActive { get; set; }
    }
}
