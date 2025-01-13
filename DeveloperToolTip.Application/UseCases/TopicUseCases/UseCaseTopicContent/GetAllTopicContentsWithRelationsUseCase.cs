using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.TopicDTOs;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopicContent
{
    public class GetAllTopicContentsWithRelationsUseCase : IGetAllTopicContentsWithRelationsUseCase
    {
        private readonly ITopicContentRepository _topicContentRepository;

        public GetAllTopicContentsWithRelationsUseCase(ITopicContentRepository topicContentRepository)
        {
            _topicContentRepository = topicContentRepository;
        }

        public async Task<List<TopicContentResponseDto>> ExecuteAsync()
        {
            var topicContents = await _topicContentRepository.GetAllWithRelationsAsync();

            return topicContents.Select(tc => new TopicContentResponseDto
            {
                Id = tc.Id,
                TopicId = tc.TopicId,
                TopicTitle = tc.Topic?.Title ?? "No Title", // Trae el título de Topic
                TopicDescription = tc.Topic?.Description ?? "No Description", // Trae la descripción
                CodeSnippet = tc.CodeSnippet,
                Explanation = tc.Explanation,
                RelatedLinks = tc.RelatedLinks,
                CreatedDate = tc.CreatedDate
            }).ToList();
        }

    }
}
