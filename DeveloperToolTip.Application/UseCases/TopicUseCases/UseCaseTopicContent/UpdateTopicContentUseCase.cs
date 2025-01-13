using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.TopicDTOs;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopicContent
{
    public class UpdateTopicContentUseCase : IUpdateTopicContentUseCase
    {
        private readonly ITopicContentRepository _topicContentRepository;

        public UpdateTopicContentUseCase(ITopicContentRepository topicContentRepository)
        {
            _topicContentRepository = topicContentRepository;
        }

        public async Task ExecuteAsync(UpdateTopicContentDto dto)
        {
            var topicContent = await _topicContentRepository.GetByIdAsync(dto.Id);
            if (topicContent == null)
            {
                throw new KeyNotFoundException($"Content with Id {dto.Id} not found.");
            }

            topicContent.Id = dto.Id;
            topicContent.TopicId = dto.TopicId;
            topicContent.CodeSnippet = dto.CodeSnippet;
            topicContent.Explanation = dto.Explanation;
            topicContent.RelatedLinks = dto.RelatedLinks;


            await _topicContentRepository.UpdateAsync(topicContent);
        }
    }
}
