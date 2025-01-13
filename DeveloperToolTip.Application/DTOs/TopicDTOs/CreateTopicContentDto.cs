using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperToolTip.Application.DTOs.TopicDTOs
{
    public class CreateTopicContentDto
    {
        public int TopicId { get; set; } // Llave foránea hacia Topic
        public string CodeSnippet { get; set; }
        public string Explanation { get; set; }
        public string? RelatedLinks { get; set; }
    }

}
