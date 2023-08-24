

using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Doctor.Application._Utilities;
using Doctor.Application.MedicalServiceAgg.Edit;
using Doctor.Application.MedicalServiceAgg.Remove;
using Doctor.Domain.MedicalServicesAgg;
using Doctor.Domain.MedicalServicesAgg.Repository;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace Doctor.Application.Test.Unit.MedicalServiceAgg.Remove;

public class Remove_MedicalService_Command_HandleTest
{
    private IMedicalServiceRepository mockRepository;
    private IFileService mockFileService;
    private IFormFile imageFile;

    public Remove_MedicalService_Command_HandleTest()
    {
        mockRepository = Substitute.For<IMedicalServiceRepository>();
        mockFileService = Substitute.For<IFileService>();
        imageFile = Substitute.For<IFormFile>();

    }
    [Fact]
    public async Task Handle_ValidRequest_DeletesMedicalServiceAndImage()
    {
        // Arrange
        var medicalService = new MedicalService("Title", "Description", "image.jpg");

        mockRepository.GetTracking(Arg.Any<long>()).Returns(medicalService);
        mockRepository.DeleteMedicalService(Arg.Any<long>()).Returns(true);

        var handler = new Remove_MedicalService_Command_Handle(mockRepository, mockFileService);
        var command = new Remove_MedicalService_Command(1);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Status.Should().Be(OperationResultStatus.Success);
       await mockRepository.Received(1).DeleteMedicalService(1);
        await mockRepository.Received(1).Save();
        mockFileService.Received(1).DeleteFile(Directories.MedicalServiceImages, "image.jpg");
    }

    [Fact]
    public async Task Handle_MedicalServiceNotFound_ReturnsNotFound()
    {
        // Arrange
       

        mockRepository.GetTracking(Arg.Any<long>()).Returns((MedicalService)null);

        var handler = new Remove_MedicalService_Command_Handle(mockRepository, mockFileService);
        var command = new Remove_MedicalService_Command(1);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Status.Should().Be(OperationResultStatus.NotFound);
        await mockRepository.DidNotReceive().DeleteMedicalService(Arg.Any<long>());
        await mockRepository.DidNotReceive().Save();
        mockFileService.DidNotReceive().DeleteFile(Arg.Any<string>(), Arg.Any<string>());
    }

    [Fact]
    public async Task Handle_FailedToDelete_ReturnsError()
    {
        // Arrange


        var medicalService = new MedicalService("Title", "Description", "image.jpg");

        mockRepository.GetTracking(Arg.Any<long>()).Returns(medicalService);
        mockRepository.DeleteMedicalService(Arg.Any<long>()).Returns(false);

        var handler = new Remove_MedicalService_Command_Handle(mockRepository, mockFileService);
        var command = new Remove_MedicalService_Command(1);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Status.Should().Be(OperationResultStatus.Error);
        result.Message.Should().Be("dont cant delete this medical service");
        await mockRepository.Received(1).DeleteMedicalService(1);
        await mockRepository.DidNotReceive().Save();
        mockFileService.DidNotReceive().DeleteFile(Arg.Any<string>(), Arg.Any<string>());
    }
}
