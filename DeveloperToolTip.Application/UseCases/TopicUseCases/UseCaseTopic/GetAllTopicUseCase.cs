using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.TopicDTOs;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopic
{
    public class GetAllTopicUseCase : IGetAllTopicUseCase
    {
        private readonly ITopicRepository _topicRepository;

        public GetAllTopicUseCase(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }
        public async Task<IEnumerable<TopicResponseDto>> ExecuteAsync()
        {
            var topic = await _topicRepository.GetAllWithRelationsAsync();
            return topic.Select(t => new TopicResponseDto
            {
                Id = t.Id,
                Title = t.Title,
                CategoryId = t.CategoryId,
                CategoryName = t.Category?.Name ?? "Unknown",
                CreatedBy = t.CreatedBy,
                CreatorName = t.Creator != null ? $"{t.Creator.FirstName} {t.Creator.LastName}" : "Unknown",
                CreatedDate = t.CreatedDate,
            });
        }

    }
}
