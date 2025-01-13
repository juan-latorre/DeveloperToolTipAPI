using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperToolTip.Application.DTOs.TopicDTOs
{
    public class TopicContentDto
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string CodeSnippet { get; set; }
        public string Explanation { get; set; }
        public string? RelatedLinks { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
