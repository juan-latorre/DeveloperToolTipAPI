using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.TopicDTOs;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseCategory
{
    public class UpdateTopicCategoryUseCase : IUpdateTopicCategoryUseCase
    {
        private readonly ITopicCategoryRepository _topicCategoryRepository;

        public UpdateTopicCategoryUseCase(ITopicCategoryRepository topicCategoryRepository)
        {
            _topicCategoryRepository = topicCategoryRepository;
        }

        public async Task ExecuteAsync(UpdateTopicCategoryDto dto)
        {
            var category = await _topicCategoryRepository.GetByIdAsync(dto.Id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with Id {dto.Id} not found.");
            }

            category.Name = dto.CategoryName;

            await _topicCategoryRepository.UpdateAsync(category);
        }
    }
}
