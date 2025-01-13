using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.DeveloperDTOs;
using DeveloperToolTip.Application.DTOs.TopicDTOs;
using DeveloperToolTip.Core.Entities;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseCategory
{
    public class GetTopicCategoryByIdUseCase : IGetTopicCategoryByIdUseCase
    {
        private readonly ITopicCategoryRepository _topicCategoryRepository;

        public GetTopicCategoryByIdUseCase(ITopicCategoryRepository topicCategoryRepository)
        {
            _topicCategoryRepository = topicCategoryRepository;
        }

        public async Task<TopicCategoryDto> ExecuteAsync(int id)
        {
            var category = await _topicCategoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"CategoryS with Id {id} not found.");
            }
            return new TopicCategoryDto { Id = category.Id, CategoryName = category.Name };
        }
    }
}
