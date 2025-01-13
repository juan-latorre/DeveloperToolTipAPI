using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.TopicDTOs;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopicContent
{
    public class GetAllTopicContentsUseCase : IGetAllTopicContentsUseCase
    {
        private readonly ITopicContentRepository _topicContentRepository;

        public GetAllTopicContentsUseCase(ITopicContentRepository topicContentRepository)
        {
            _topicContentRepository = topicContentRepository;
        }

        public async Task<IEnumerable<TopicContentResponseDto>> ExecuteAsync()
        {
            var topicContent = await _topicContentRepository.GetAllAsync();
            return topicContent.Select(tc => new TopicContentResponseDto
            {
                Id = tc.Id,
                TopicId = tc.TopicId,
                CodeSnippet = tc.CodeSnippet,
                Explanation = tc.Explanation,
                RelatedLinks = tc.RelatedLinks,
                CreatedDate = tc.CreatedDate,
             
            });
        }
    }
}
