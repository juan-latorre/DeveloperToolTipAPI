using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperToolTip.Application.DTOs.TopicDTOs
{
    public class CreateTopicDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; } // Llave foránea a la categoría
        public int CreatedBy { get; set; } // Llave foránea al creador
    }

}
