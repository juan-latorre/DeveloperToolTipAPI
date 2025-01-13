using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.TopicDTOs;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopic
{
    public class UpdateTopicUseCase : IUpdateTopicUseCase
    {
        private readonly ITopicRepository _topicRepository;

        public UpdateTopicUseCase(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task ExecuteAsync(UpdateTopicDto dto)
        {
            var topic = await _topicRepository.GetByIdAsync(dto.Id);
            if (topic == null)
            {
                throw new KeyNotFoundException($"Topic with Id {dto.Id} not found.");
            }

            topic.Id = dto.Id;
            topic.Title = dto.Title;
            topic.Description = dto.Description;
            topic.CategoryId = dto.CategoryId;
      

            await _topicRepository.UpdateAsync(topic);
        }

    }
}
