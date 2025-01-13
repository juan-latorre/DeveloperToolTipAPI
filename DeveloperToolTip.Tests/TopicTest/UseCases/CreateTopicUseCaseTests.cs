using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.DTOs.TopicDTOs;
using DeveloperToolTip.Application.UseCases.TopicUseCases;
using DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopic;
using DeveloperToolTip.Core.Entities;
using DeveloperToolTip.Core.Interfaces;
using Moq;
using Xunit;

namespace DeveloperToolTip.Tests.TopicTest.UseCases
{
    public class CreateTopicUseCaseTests
    {
        [Fact]
        public async Task ExecuteAsync_CreatesTopicSuccessfully()
        {
            // Arrange
            var mockRepository = new Mock<ITopicRepository>();
            mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Topic>()))
                          .Returns(Task.CompletedTask);

            var useCase = new CreateTopicUseCase(mockRepository.Object);

            var newTopic = new CreateTopicDto
            {
                Title = "New Topic",
                Description = "This is a test topic",
                CategoryId = 1,
                CreatedBy = 1
            };

            // Act
            await useCase.ExecuteAsync(newTopic);

            // Assert
            mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Topic>()), Times.Once);
        }
    }
}
