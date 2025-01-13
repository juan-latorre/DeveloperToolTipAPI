using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseCategory
{
    public class DeleteTopicCategoryUseCase : IDeleteTopicCategoryUseCase
    {
        private readonly ITopicCategoryRepository _topicCategoryRepository;

        public DeleteTopicCategoryUseCase(ITopicCategoryRepository topicCategoryRepository)
        {
            _topicCategoryRepository = topicCategoryRepository;
        }

        public async Task ExecuteAsync(int categoryId)
        {
            var category = await _topicCategoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with Id {categoryId} not found.");
            }

            await _topicCategoryRepository.DeleteAsync(categoryId);

        }

    }
}
