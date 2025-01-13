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
    public class GetAllTopicsUseCaseTests
    {
        [Fact]
        public async Task ExecuteAsync_ReturnsAllTopics()
        {
            // Arrange
            var mockRepository = new Mock<ITopicRepository>();
            mockRepository.Setup(repo => repo.GetAllWithRelationsAsync())
                .ReturnsAsync(new List<Topic>
                {
                    TestDataHelper.CreateTopic(1, "Title 1", "Description 1"),
                    TestDataHelper.CreateTopic(2, "Title 2", "Description 2")
                });

            var useCase = new GetAllTopicUseCase(mockRepository.Object);

            // Act
            var result = await useCase.ExecuteAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, t => t.Title == "Title 1");
        }
    }
}
