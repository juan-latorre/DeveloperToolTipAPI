using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperToolTip.Application.DTOs.TopicDTOs
{
    public class TopicDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; } // Nombre de la categoría
        public string CreatorName { get; set; } // Nombre del creador
        public DateTime CreatedDate { get; set; }
    }
}
