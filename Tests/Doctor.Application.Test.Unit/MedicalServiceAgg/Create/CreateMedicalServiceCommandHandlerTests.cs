using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Doctor.Application.MedicalServiceAgg.Create;
using Doctor.Application.MedicalServiceAgg.Edit;
using Doctor.Domain.MedicalServicesAgg;
using Doctor.Domain.MedicalServicesAgg.Repository;
using FluentAssertions;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Doctor.Application.Test.Unit.MedicalServiceAgg.Create;

public class CreateMedicalServiceCommandHandlerTests
{
    private IMedicalServiceRepository mockRepository;
    private IFileService mockFileService;
    private IFormFile imageFile;

    public CreateMedicalServiceCommandHandlerTests()
    {
        mockRepository = Substitute.For<IMedicalServiceRepository>();
        mockFileService = Substitute.For<IFileService>();
        imageFile = Substitute.For<IFormFile>();

    }


    [Theory]
    [InlineData("test", "test", null)]
    public async Task Create_MedicalService_Command_Handler_Should_Return_Error_When_Data_NotValid(string title, string shortDesc, IFormFile formFile)
    {
        // Arrange

        var command = new Create_MedicalService_Command(title, shortDesc, formFile);
        var handler = new Create_MedicalService_Command_Handler(mockRepository, mockFileService);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Status.Should().Be(OperationResultStatus.Error);
    }

    [Fact]
    public async Task Create_MedicalService_Command_Handler_Should_Return_Success_When_Data_IsOk()
    {
        // Arrange
        var medicalService = new MedicalService("s1", "s1", "ae766443-c8f5-475c-a3ef-2c5cd7ccde411229017579420.jpg");

        mockRepository.GetTracking(Arg.Any<long>()).Returns(medicalService);
        mockFileService.SaveFileAndGenerateName(Arg.Any<IFormFile>(), Arg.Any<string>()).Returns("new_image.jpg");

        var handler = new Create_MedicalService_Command_Handler(mockRepository, mockFileService);

        var command = new Create_MedicalService_Command("New Title", "New Description", Substitute.For<IFormFile>());

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Status.Should().Be(OperationResultStatus.Success);
        await mockRepository.Received(1).Save();
    }

}
