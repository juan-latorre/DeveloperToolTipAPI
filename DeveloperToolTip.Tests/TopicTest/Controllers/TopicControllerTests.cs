using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.API.Controllers;
using DeveloperToolTip.Application.DTOs;
using DeveloperToolTip.Application.DTOs.TopicDTOs;
using DeveloperToolTip.Application.UseCases.TopicUseCases;
using DeveloperToolTip.Application.UseCases.TopicUseCases.UseCaseTopic;
using DeveloperToolTip.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DeveloperToolTip.Tests.TopicTest.Controllers
{
    public class TopicControllerTests
    {
        private readonly Mock<IGetAllTopicUseCase> _mockGetAllTopicUseCase;
        private readonly Mock<IGetTopicByIdUseCase> _mockGetTopicByIdUseCase;
        private readonly Mock<ICreateTopicUseCase> _mockCreateTopicUseCase;
        private readonly Mock<IUpdateTopicUseCase> _mockUpdateTopicUseCase;
        private readonly Mock<IDeleteTopicUseCase> _mockDeleteTopicUseCase;

        private readonly TopicController _controller;

        public TopicControllerTests()
        {
            // Crear instancias simuladas (mocks) para cada caso de uso
            _mockGetAllTopicUseCase = new Mock<IGetAllTopicUseCase>();
            _mockGetTopicByIdUseCase = new Mock<IGetTopicByIdUseCase>();
            _mockCreateTopicUseCase = new Mock<ICreateTopicUseCase>();
            _mockUpdateTopicUseCase = new Mock<IUpdateTopicUseCase>();
            _mockDeleteTopicUseCase = new Mock<IDeleteTopicUseCase>();

            // Pasar todas las simulaciones al constructor del controlador
            _controller = new TopicController(
                _mockGetAllTopicUseCase.Object,
                _mockGetTopicByIdUseCase.Object,
                _mockCreateTopicUseCase.Object,
                _mockUpdateTopicUseCase.Object,
                _mockDeleteTopicUseCase.Object
            );
        }

        [Fact]
        public async Task GetAll_ReturnsCorrectTopics()
        {
            // Arrange
            var expectedTopics = new List<TopicResponseDto>
        {
            new TopicResponseDto { Id = 1, Title = "Topic 1", CategoryName = "Category 1" },
            new TopicResponseDto { Id = 2, Title = "Topic 2", CategoryName = "Category 2" }
        };

            _mockGetAllTopicUseCase
                .Setup(uc => uc.ExecuteAsync())
                .ReturnsAsync(expectedTopics);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var topics = Assert.IsAssignableFrom<IEnumerable<TopicResponseDto>>(okResult.Value);
            Assert.Equal(2, topics.Count());
        }
    }

}
