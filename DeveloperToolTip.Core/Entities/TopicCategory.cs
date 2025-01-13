using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperToolTip.Core.Entities
{
    [Table("TopicCategory")]
    public class TopicCategory
    {
        public int Id { get; set; } // Identificador único

        public string Name { get; set; } // Nombre único de la categoría

        // Inicializa CreatedDate con una fecha válida (hoy en UTC)
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
           
    }
}
