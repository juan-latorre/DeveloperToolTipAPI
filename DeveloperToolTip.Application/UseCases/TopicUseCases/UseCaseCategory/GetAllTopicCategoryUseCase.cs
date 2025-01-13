using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.TopicDTOs;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseCategory
{
    public class GetAllTopicCategoryUseCase : IGetAllTopicCategoryUseCase
    {
        private readonly ITopicCategoryRepository _topicCategoryRepository;

        public GetAllTopicCategoryUseCase(ITopicCategoryRepository topicCategoryRepository)
        {
            _topicCategoryRepository = topicCategoryRepository;
        }

        public async Task<IEnumerable<TopicCategoryDto>> ExecuteAsync()
        {
            var categories = await _topicCategoryRepository.GetAllAsync();
            return categories.Select(c => new TopicCategoryDto
            {
                Id = c.Id,
                CategoryName = c.Name
            });
        }
    }
}
