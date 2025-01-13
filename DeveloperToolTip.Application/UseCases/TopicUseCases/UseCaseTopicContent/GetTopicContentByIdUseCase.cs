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
    public class GetTopicContentByIdUseCase : IGetTopicContentByIdUseCase
    {
        private readonly ITopicContentRepository _topicContentRepository;

        public GetTopicContentByIdUseCase(ITopicContentRepository topicContentRepository)
        {
            _topicContentRepository = topicContentRepository;
        }

        public async Task<TopicContentResponseDto> ExecuteAsync(int id)
        {
            var topicContent = await _topicContentRepository.GetByIdWithRelationsAsync(id);

            if (topicContent == null)
                throw new KeyNotFoundException($"Content with Id {id} not found.");

            return new TopicContentResponseDto
            {
                Id = topicContent.Id,
                TopicId = topicContent.TopicId,
                TopicTitle = topicContent.Topic?.Title ?? "No Title", // Manejo seguro de null
                CodeSnippet = topicContent.CodeSnippet,
                Explanation = topicContent.Explanation,
                RelatedLinks = topicContent.RelatedLinks,
                CreatedDate = topicContent.CreatedDate
            };
        }

    }
}
