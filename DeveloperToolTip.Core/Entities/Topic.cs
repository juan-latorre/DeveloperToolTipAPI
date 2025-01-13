using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperToolTip.Core.Entities
{
    [Table("Topic")]
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Llave foránea: Relación con TopicCategory
        public int CategoryId { get; set; }
        public virtual TopicCategory Category { get; set; }

        // Llave foránea: Relación con Developer
        [ForeignKey("CreatedBy")] // Relación con la columna CreatedBy
        public int CreatedBy { get; set; }
        public virtual Developer Creator { get; set; }

        // Fecha de creación
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Propiedad de navegación: Relación uno a muchos con TopicContent
        public virtual ICollection<TopicContent>? TopicContents { get; set; }
    }
}
