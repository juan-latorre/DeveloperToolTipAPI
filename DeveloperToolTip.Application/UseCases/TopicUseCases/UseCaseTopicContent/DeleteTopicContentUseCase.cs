using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopicContent
{
    public class DeleteTopicContentUseCase : IDeleteTopicContentUseCase
    {
        private readonly ITopicContentRepository _topicContentRepository;

        public DeleteTopicContentUseCase(ITopicContentRepository topicContentRepository)
        {
            _topicContentRepository = topicContentRepository;
        }

        public async Task ExecuteAsync(int topicContentId)
        {
            var topicContent = await _topicContentRepository.GetByIdAsync(topicContentId);
            if (topicContent == null)
            {
                throw new KeyNotFoundException($"Content with Id {topicContentId} not found.");
            }

            await _topicContentRepository.DeleteAsync(topicContentId);

        }
    }
}
