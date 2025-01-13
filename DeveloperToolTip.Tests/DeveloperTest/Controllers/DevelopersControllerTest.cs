using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperToolTip.API.Controllers;
using DeveloperToolTip.Application.UseCases;
using DeveloperToolTip.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using DeveloperToolTip.Application.DTOs.DeveloperDTOs;
using DeveloperToolTip.Application.UseCases.DeveloperUseCases;


namespace DeveloperToolTip.Tests.DeveloperTest.Controllers
{
    public class DevelopersControllerTests
    {
        private readonly Mock<IGetAllDevelopersUseCase> _mockGetAllUseCase;
        private readonly Mock<ICreateDeveloperUseCase> _mockCreateUseCase;
        private readonly Mock<IDeleteDeveloperUseCase> _mockDeleteUseCase;
        private readonly Mock<IGetDeveloperByIdUseCase> _mockGetByIdUseCase;
        private readonly Mock<IUpdateDeveloperUseCase> _mockUpdateUseCase;

        private readonly DevelopersController _controller;

        public DevelopersControllerTests()
        {
            // Crear los mocks para todas las dependencias
            _mockGetAllUseCase = new Mock<IGetAllDevelopersUseCase>();
            _mockCreateUseCase = new Mock<ICreateDeveloperUseCase>();
            _mockDeleteUseCase = new Mock<IDeleteDeveloperUseCase>();
            _mockGetByIdUseCase = new Mock<IGetDeveloperByIdUseCase>();
            _mockUpdateUseCase = new Mock<IUpdateDeveloperUseCase>();

            // Instanciar el controlador con las dependencias mockeadas
            _controller = new DevelopersController(
                _mockGetAllUseCase.Object,
                _mockCreateUseCase.Object,
                _mockDeleteUseCase.Object,
                _mockGetByIdUseCase.Object,
                _mockUpdateUseCase.Object
            );
        }

        [Fact]
        public async Task GetAll_ReturnsOkResultWithDevelopers()
        {
            // Arrange
            var developers = new List<DeveloperDto>
            {
                new DeveloperDto { Id = 1, FirstName = "Juan", LastName = "Perez" },
                new DeveloperDto { Id = 2, FirstName = "Maria", LastName = "Lopez" }
            };

            _mockGetAllUseCase.Setup(uc => uc.ExecuteAsync())
                .ReturnsAsync(developers);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<DeveloperDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }
    }
}
