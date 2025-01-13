using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.TopicDTOs;
using DeveloperToolTip.Core.Entities;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopicContent
{
    public class CreateTopicContentUseCase : ICreateTopicContentUseCase
    {
        private readonly ITopicContentRepository _topicContentRepository;

        public CreateTopicContentUseCase(ITopicContentRepository topicContentRepository)
        {
            _topicContentRepository = topicContentRepository;
        }

        public async Task<int> ExecuteAsync(CreateTopicContentDto dto)
        {
            var topicContent = new TopicContent
            {
                TopicId = dto.TopicId,
                CodeSnippet = dto.CodeSnippet,
                Explanation = dto.Explanation,
                RelatedLinks = dto.RelatedLinks,
                CreatedDate = DateTime.UtcNow
            };

            await _topicContentRepository.AddAsync(topicContent);

            return topicContent.Id;

        }


    }
}
