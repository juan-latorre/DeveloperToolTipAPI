using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperToolTip.Core.Entities
{
    [Table("TopicContent")]
    public class TopicContent
    {
        public int Id { get; set; }

        // Llave foránea: Relación con Topic
        [ForeignKey("TopicId")] // Relación con la columna TopicId
        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }

        // Propiedades específicas del contenido
        public string CodeSnippet { get; set; }
        public string Explanation { get; set; }
        public string? RelatedLinks { get; set; }

        // Fecha de creación
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
