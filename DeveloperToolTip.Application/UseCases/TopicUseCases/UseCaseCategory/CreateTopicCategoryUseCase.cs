using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.TopicDTOs;
using DeveloperToolTip.Core.Entities;
using DeveloperToolTip.Core.Interfaces;

namespace DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseCategory
{
    public class CreateTopicCategoryUseCase : ICreateTopicCategoryUseCase
    {
        private readonly ITopicCategoryRepository _topicCategoryRepository;

        public CreateTopicCategoryUseCase(ITopicCategoryRepository topicCategoryRepository)
        {
            _topicCategoryRepository = topicCategoryRepository;
        }

        public async Task<int> ExecuteAsync(CreateTopicCategoryDto dto)
        {
            var category = new TopicCategory
            {
                Name = dto.CategoryName,
                CreatedDate = DateTime.UtcNow // Asigna la fecha actual válida para SQL Server
            };
            await _topicCategoryRepository.AddAsync(category);

            return category.Id;
        }
    }
}
