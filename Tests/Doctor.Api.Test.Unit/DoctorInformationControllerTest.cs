
using Common.Application;
using Common.AspNetCore;
using Doctor.Api.Controllers;
using Doctor.Application.DoctorInformationAgg.Create;
using Doctor.Application.DoctorInformationAgg.Edit;
using Doctor.Presentation.Facade.DoctorInformationAgg;
using Doctor.Query.DoctorInformationAgg.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace Doctor.Api.Test.Unit;

public class DoctorInformationControllerTest
{
    private readonly IDoctorInformationFacade facadeMock;
    private readonly IFormFile formFile;

    public DoctorInformationControllerTest()
    {
        facadeMock = Substitute.For<IDoctorInformationFacade>();
         formFile = Substitute.For<IFormFile>();
    }
    [Fact]
    public async Task GetList_Should_Return_ApiResult()
    {
        // Arrange
        var controller = new DoctorInformationController(facadeMock);

        var doctorInfos = new List<DoctorInformationDto>
            {
                new DoctorInformationDto { FullName = "John Doe" },
                new DoctorInformationDto { FullName = "Jane Smith" }
            };

        facadeMock.GetList().Returns(doctorInfos);

        // Act
        var result = await controller.GetList();

        // Assert
        result.Should().BeOfType<ApiResult<List<DoctorInformationDto>>>();
    }

    [Fact]
    public async Task GetList_Should_Return_DoctorInfos()
    {
        // Arrange
        
        var controller = new DoctorInformationController(facadeMock);

        var doctorInfos = new List<DoctorInformationDto>
            {
                new DoctorInformationDto { FullName = "John Doe" },
                new DoctorInformationDto { FullName = "Jane Smith" }
            };

        facadeMock.GetList().Returns(doctorInfos);

        // Act
        var result = await controller.GetList();

        // Assert
        result.Data.Should().BeEquivalentTo(doctorInfos);
    }

    [Fact]
    public async Task GetById_Should_Return_ApiResult()
    {
        // Arrange
        
        var controller = new DoctorInformationController(facadeMock);

        var doctorInfoId = 1;
        var doctorInfoDto = new DoctorInformationDto { FullName = "John Doe" };

        facadeMock.GetById(doctorInfoId).Returns(doctorInfoDto);

        // Act
        var result = await controller.GetById(doctorInfoId);

        // Assert
        result.Should().BeOfType<ApiResult<DoctorInformationDto?>>();
    }

    [Fact]
    public async Task GetById_Should_Return_DoctorInfoDto()
    {
        // Arrange
        
        var controller = new DoctorInformationController(facadeMock);

        var doctorInfoId = 1;
        var doctorInfoDto = new DoctorInformationDto { FullName = "John Doe" };

        facadeMock.GetById(doctorInfoId).Returns(doctorInfoDto);

        // Act
        var result = await controller.GetById(doctorInfoId);

        // Assert
        result.Data.Should().BeEquivalentTo(doctorInfoDto);
    }


    [Fact]
    public async Task Create_Should_Return_ApiResult()
    {
        // Arrange
        
        var controller = new DoctorInformationController(facadeMock);
      
        var command = new Create_DoctorInfo_Command("John Doe", formFile,"","","","");

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
        var controller = new DoctorInformationController(facadeMock);

        var command = new Edit_DoctorInfo_Command(1, "John Doe", formFile, "12345", "john@example.com", "Short desc", "Description");

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
        var controller = new DoctorInformationController(facadeMock);

        var command = new Edit_DoctorInfo_Command(1, "John Doe", formFile, "12345", "john@example.com", "Short desc", "Description");

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
        
        var controller = new DoctorInformationController(facadeMock);

        var doctorInfoId = 1;

        facadeMock.Remove(doctorInfoId).Returns(OperationResult.Success());

        // Act
        var result = await controller.Delete(doctorInfoId);

        // Assert
        result.Should().BeOfType<ApiResult>();
    }
}
