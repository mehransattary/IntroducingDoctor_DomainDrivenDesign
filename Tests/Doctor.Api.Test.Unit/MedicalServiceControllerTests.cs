

using Common.Application;
using Common.AspNetCore;
using Doctor.Api.Controllers;
using Doctor.Application.MedicalServiceAgg.Create;
using Doctor.Application.MedicalServiceAgg.Edit;
using Doctor.Application.MedicalServiceAgg.Remove;
using Doctor.Presentation.Facade.MedicalServiceAgg;
using Doctor.Query.MedicalServiceAgg.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NSubstitute;

namespace Doctor.Api.Test.Unit;

public class MedicalServiceControllerTests
{
    [Fact]
    public async Task GetById_WithValidId_ReturnsOkResultWithMatchingDto()
    {
        // Arrange
        var facadeMock = new Mock<IMedicalServiceFacade>();
        var medicalServiceDto = new MedicalServiceDto { Title="t1",ShortDescription="sq",Image="image1" };
        facadeMock.Setup(f => f.GetById(It.IsAny<long>())).ReturnsAsync(medicalServiceDto);

        var controller = new MedicalServiceController(facadeMock.Object);
        var medicalServiceId = 1; // Replace with a valid ID

        // Act
        var result = await controller.GetById(medicalServiceId);

        // Assert


        result.Should().BeOfType<ApiResult<MedicalServiceDto>>()
              .Which.Data.Should().BeEquivalentTo(medicalServiceDto);

    }

    [Fact]
    public async Task GetById_WithInvalidId_ReturnsNotFoundResult()
    {
        // Arrange
        var facadeMock = new Mock<IMedicalServiceFacade>();
        facadeMock.Setup(f => f.GetById(It.IsAny<long>())).ReturnsAsync((MedicalServiceDto)null);

        var controller = new MedicalServiceController(facadeMock.Object);
        var medicalServiceId = 123; // Replace with an invalid ID

        // Act
        var result = await controller.GetById(medicalServiceId);

        // Assert
        result.Should().BeOfType<ApiResult<MedicalServiceDto>>()
            .Which.Data.Should().BeEquivalentTo((MedicalServiceDto)null);
    }
    [Fact]
    public async Task GetList_ReturnsListOfMedicalServiceDto()
    {
        // Arrange
        var facadeMock = new Mock<IMedicalServiceFacade>();
        var controller = new MedicalServiceController(facadeMock.Object);

        var expectedDtoList = new List<MedicalServiceDto>
        {
          new MedicalServiceDto { Title = "t1", ShortDescription = "sq", Image = "image1" },
          new MedicalServiceDto { Title = "t2", ShortDescription = "sq2", Image = "image2" }
       };

        facadeMock.Setup(f => f.GetList()).ReturnsAsync(expectedDtoList);

        // Act
        var result = await controller.GetList();

        // Assert
        result.Should().BeOfType<ApiResult<List<MedicalServiceDto>>>()
            .Which.Data.Should().BeEquivalentTo(expectedDtoList);
    }

    [Fact]
    public async Task Create_MedicalService_Returns_ApiResult()
    {
        // Arrange
        var facadeMock = new Mock<IMedicalServiceFacade>();
        var controller = new MedicalServiceController(facadeMock.Object);

        var command = new Create_MedicalService_Command ("t1","s1", Arg.Any<IFormFile>());

        facadeMock.Setup(f => f.Create(command)).ReturnsAsync(OperationResult.Success());

        // Act
        var result = await controller.Create(command);

        // Assert
        result.Should().BeOfType<ApiResult>();
            
    }
    [Fact]
    public async Task Edit_MedicalService_Returns_ApiResult_Data()
    {
        // Arrange
        var facadeMock = new Mock<IMedicalServiceFacade>();
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        var httpContext = new DefaultHttpContext();

        var controller = new MedicalServiceController(facadeMock.Object);
        controller.ControllerContext.HttpContext = httpContext;

        var command = new Edit_MedicalService_Command(1, "t2", "s2", null);
        var operationResult = OperationResult<long>.Success(1);
        facadeMock.Setup(f => f.Edit(command)).ReturnsAsync(operationResult);

        // Act
        var result = await controller.Edit(command);

        // Assert
        result.Should().BeOfType<ApiResult<long>>();
    }

    [Fact]
    public async Task Delete_MedicalService_Returns_ApiResult_Data()
    {
        // Arrange
        var facadeMock = new Mock<IMedicalServiceFacade>();
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        var httpContext = new DefaultHttpContext();

        var controller = new MedicalServiceController(facadeMock.Object);
        controller.ControllerContext.HttpContext = httpContext;

        var command = new Remove_MedicalService_Command(1);
        facadeMock.Setup(f => f.Remove(command.medicalServiceId)).ReturnsAsync(OperationResult.Success());

        // Act
        var result = await controller.Delete(command.medicalServiceId);

        // Assert
        result.Should().BeOfType<ApiResult>();
    }
}


