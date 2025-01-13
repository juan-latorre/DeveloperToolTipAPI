using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.Application.UseCases;
using DeveloperToolTip.Application.UseCases.DeveloperUseCases;
using DeveloperToolTip.Core.Entities;
using DeveloperToolTip.Core.Interfaces;
using DeveloperToolTip.Tests.Helpers;
using Moq;
using Xunit;

namespace DeveloperToolTip.Tests.DeveloperTest.UseCases
{
    public class GetAllDevelopersUseCaseTests
    {
        [Fact]
        public async Task ExecuteAsync_ReturnsAllDevelopers()
        {
            // Arrange
            var mockRepository = new Mock<IDeveloperRepository>();
            mockRepository.Setup(repo => repo.GetAllAsync())
                          .ReturnsAsync(new List<Developer>
                          {
                             TestDataHelper.CreateDeveloper(1, "Juan", "Perez"),
                             TestDataHelper.CreateDeveloper(2, "Maria", "Gomez")
                          });

            var useCase = new GetAllDevelopersUseCase(mockRepository.Object);

            // Act
            var result = await useCase.ExecuteAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, d => d.FirstName == "Juan");
        }
    }
}
