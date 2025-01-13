using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.UseCases.TopicUseCases;
using DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopic;
using DeveloperToolTip.Core.Entities;
using DeveloperToolTip.Core.Interfaces;
using DeveloperToolTip.Tests.Helpers;
using Moq;
using Xunit;

namespace DeveloperToolTip.Tests.TopicTest.UseCases
{
    public class GetTopicByIdUseCaseTests
    {
        [Fact]
        public async Task ExecuteAsync_ReturnsTopicById()
        {
            // Arrange
            var mockRepository = new Mock<ITopicRepository>();
            var topicId = 1;
            mockRepository.Setup(repo => repo.GetByIdWithRelationsAsync(topicId))
                .ReturnsAsync(TestDataHelper.CreateTopic(topicId, "Title 1", "Description 1"));

            var useCase = new GetTopicByIdUseCase(mockRepository.Object);

            // Act
            var result = await useCase.ExecuteAsync(topicId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(topicId, result.Id);
            Assert.Equal("Title 1", result.Title);
        }
    }
}
