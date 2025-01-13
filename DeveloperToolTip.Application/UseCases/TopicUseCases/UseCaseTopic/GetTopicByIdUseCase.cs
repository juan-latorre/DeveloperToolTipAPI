using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.DeveloperDTOs;
using DeveloperToolTip.Application.DTOs.TopicDTOs;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopic
{
    public class GetTopicByIdUseCase : IGetTopicByIdUseCase
    {
        private readonly ITopicRepository _topicRepository;

        public GetTopicByIdUseCase(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<TopicResponseDto> ExecuteAsync(int id)
        {
            var topic = await _topicRepository.GetByIdWithRelationsAsync(id);

            if (topic == null)
            {
                throw new KeyNotFoundException($"Topic with Id {id} not found.");
            }

            return new TopicResponseDto
            {
                Id = topic.Id,
                Title = topic.Title,
                Description = topic.Description,
                CategoryId = topic.CategoryId,
                CategoryName = topic.Category?.Name ?? "Unknown",
                CreatedBy = topic.CreatedBy,
                CreatorName = topic.Creator != null ? $"{topic.Creator.FirstName} {topic.Creator.LastName}" : "Unknown",
                CreatedDate = topic.CreatedDate
            };
        }
    }

}
