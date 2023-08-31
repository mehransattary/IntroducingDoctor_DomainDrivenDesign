using Common.Application;
using Common.AspNetCore;
using Doctor.Api.Controllers;

using Doctor.Application.ContactUsAgg.Create;
using Doctor.Application.ContactUsAgg.Edit;
using Doctor.Presentation.Facade.AboutUsAgg;
using Doctor.Query.AboutUsAgg.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace Doctor.Api.Test.Unit;

public class AboutUsControllerTest
{
    private readonly IAboutUsFacade facadeMock;
    private readonly IFormFile formFile;

    public AboutUsControllerTest()
    {
        facadeMock = Substitute.For<IAboutUsFacade>();
        formFile = Substitute.For<IFormFile>();
    }

    [Fact]
    public async Task Get_AboutUs_Should_Return_ApiResult()
    {
        // Arrange
        var controller = new AboutUsController(facadeMock);

        var aboutusDto = new AboutUsDto { Title = "John Doe" };

        facadeMock.GetAboutUs().Returns(aboutusDto);

        // Act
        var result = await controller.Get();

        // Assert
        result.Should().BeOfType<ApiResult<AboutUsDto>>();
    }

    [Fact]
    public async Task Create_AboutUs_Should_Return_ApiResult()
    {
        // Arrange
        var controller = new AboutUsController(facadeMock);

        var command = new Create_ContactUs_Command("Test", formFile, "");

        facadeMock.Create(command).Returns(OperationResult.Success());

        // Act
        var result = await controller.Create(command);

        // Assert
        result.Should().BeOfType<ApiResult>();
    }

    [Fact]
    public async Task Edit_Should_Return_ApiResult()
    {
        // Arrange
        var controller = new AboutUsController(facadeMock);

        var command = new Edit_ContactUs_Command(1, "test", formFile, " ");

        var operationResult = OperationResult.Success();
        facadeMock.Edit(command).Returns(operationResult);

        // Act
        var result = await controller.Edit(command);

        // Assert
        result.Should().BeOfType<ApiResult>();
    }

    [Fact]
    public async Task Edit_Should_Return_CommandResult()
    {
        // Arrange
        var controller = new AboutUsController(facadeMock);

        var command = new Edit_ContactUs_Command(1, " ", formFile, " ");

        var operationResult = OperationResult.Success();
        facadeMock.Edit(command).Returns(operationResult);

        // Act
        var result = await controller.Edit(command);

        // Assert
        result.MetaData.AppStatusCode.Should().Be(AppStatusCode.Success);
    }
    [Fact]
    public async Task Delete_Should_Return_ApiResult()
    {
        // Arrange

        var controller = new AboutUsController(facadeMock);

        var aboutusId = 1;

        facadeMock.Remove(aboutusId).Returns(OperationResult.Success());

        // Act
        var result = await controller.Delete(aboutusId);

        // Assert
        result.Should().BeOfType<ApiResult>();
    }
}
