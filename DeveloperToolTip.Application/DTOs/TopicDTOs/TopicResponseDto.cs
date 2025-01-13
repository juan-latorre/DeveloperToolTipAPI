using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperToolTip.Application.DTOs.TopicDTOs
{
    public class TopicResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } // Incluye el nombre de la categoría
        public int CreatedBy { get; set; }
        public string CreatorName { get; set; } // Incluye el nombre del creador
        public DateTime CreatedDate { get; set; }
    }

}
