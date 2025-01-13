using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.UseCases.DeveloperUseCases;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopic
{
    public class DeleteTopicUseCase : IDeleteTopicUseCase
    {
        private readonly ITopicRepository _topicRepository;

        public DeleteTopicUseCase(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task ExecuteAsync(int topicId)
        {
            var topic = await _topicRepository.GetByIdAsync(topicId);
            if (topic == null)
            {
                throw new KeyNotFoundException($"Topic with Id {topicId} not found.");
            }

            await _topicRepository.DeleteAsync(topicId);

        }
    }
}
