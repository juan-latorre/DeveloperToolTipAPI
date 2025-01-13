using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Core.Interfaces;
using DeveloperToolTip.Application.DTOs.TopicDTOs;
using DeveloperToolTip.Core.Entities;

namespace DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopic
{
    public class CreateTopicUseCase : ICreateTopicUseCase
    {
        private readonly ITopicRepository _topicRepository;

        public CreateTopicUseCase(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<int> ExecuteAsync(CreateTopicDto dto) 
        {
            var topic = new Topic
            { 
             Title = dto.Title,
             Description = dto.Description,
             CategoryId = dto.CategoryId,
             CreatedBy = dto.CreatedBy,
             CreatedDate = DateTime.UtcNow
            };
        
            await _topicRepository.AddAsync(topic);

            return topic.Id;
        
        }


    }
}
