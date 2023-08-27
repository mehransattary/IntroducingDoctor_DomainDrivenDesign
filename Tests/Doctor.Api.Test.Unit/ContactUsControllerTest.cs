using Common.Application;
using Common.AspNetCore;
using Doctor.Api.Controllers;
using Doctor.Application.ContactUsAgg.Create;
using Doctor.Application.ContactUsAgg.Edit;
using Doctor.Presentation.Facade.ContactUsAgg;
using Doctor.Query.ContactUsAgg.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace Doctor.Api.Test.Unit;

public class ContactUsControllerTest
{
    private readonly IContactUsFacade facadeMock;
    private readonly IFormFile formFile;

    public ContactUsControllerTest()
    {
        facadeMock = Substitute.For<IContactUsFacade>();
        formFile = Substitute.For<IFormFile>();
    }

    [Fact]
    public async Task Get_ContactUs_Should_Return_ApiResult()
    {
        // Arrange
        var controller = new ContactUsController(facadeMock);

        var ContactUsDto = new ContactUsDto { Title = "John Doe" };

        facadeMock.GetContactUs().Returns(ContactUsDto);

        // Act
        var result = await controller.Get();

        // Assert
        result.Should().BeOfType<ApiResult<ContactUsDto>>();
    }

    [Fact]
    public async Task Create_ContactUs_Should_Return_ApiResult()
    {
        // Arrange
        var controller = new ContactUsController(facadeMock);

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
        var controller = new ContactUsController(facadeMock);

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
        var controller = new ContactUsController(facadeMock);

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

        var controller = new ContactUsController(facadeMock);

        var ContactUsId = 1;

        facadeMock.Remove(ContactUsId).Returns(OperationResult.Success());

        // Act
        var result = await controller.Delete(ContactUsId);

        // Assert
        result.Should().BeOfType<ApiResult>();
    }
}
