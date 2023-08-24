

using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Doctor.Application._Utilities;
using Doctor.Application.MedicalServiceAgg.Create;
using Doctor.Application.MedicalServiceAgg.Edit;
using Doctor.Domain.MedicalServicesAgg;
using Doctor.Domain.MedicalServicesAgg.Repository;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using NSubstitute;
using Common.Application.SecurityUtil;
namespace Doctor.Application.Test.Unit.MedicalServiceAgg.Edit;



public class EditMedicalServiceCommandHandlerTests
{
    private IMedicalServiceRepository mockRepository;
    private IFileService mockFileService;
    private IFormFile imageFile;

    public EditMedicalServiceCommandHandlerTests()
    {
        mockRepository = Substitute.For<IMedicalServiceRepository>();
        mockFileService = Substitute.For<IFileService>();
         imageFile = Substitute.For<IFormFile>();

    }
    [Fact]
    public async Task Handle_ValidRequest_ReturnsSuccess()
    {
        // Arrange
        var medicalService = new MedicalService("s1", "s1", "ae766443-c8f5-475c-a3ef-2c5cd7ccde411229017579420.jpg");

        mockRepository.GetTracking(Arg.Any<long>()).Returns(medicalService);

        mockFileService.SaveFileAndGenerateName(Arg.Any<IFormFile>(), Arg.Any<string>()).Returns("new_image.jpg");



        var handler = new Edit_MedicalService_Command_Handler(mockRepository, mockFileService);

        var command = new Edit_MedicalService_Command(1, "New Title", "New Description", imageFile);



        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Status.Should().Be(OperationResultStatus.Success);
        result.Data.Should().Be(1);
        medicalService.Title.Should().Be("New Title");
        medicalService.ShortDescription.Should().Be("New Description");
        medicalService.Image.Should().Be("ae766443-c8f5-475c-a3ef-2c5cd7ccde411229017579420.jpg");
        await mockRepository.Received(1).Save();
        mockFileService.DeleteFile(Directories.MedicalServiceImages, "ae766443-c8f5-475c-a3ef-2c5cd7ccde411229017579420.jpg");
    }

    [Fact]
    public async Task Handle_MedicalServiceNotFound_ReturnsNotFound()
    {
        // Arrange
        mockRepository.GetTracking(Arg.Any<long>()).Returns((MedicalService)null);

        var handler = new Edit_MedicalService_Command_Handler(mockRepository, mockFileService);

        var command = new Edit_MedicalService_Command(1, "New Title", "New Description", imageFile);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Status.Should().Be(OperationResultStatus.NotFound);
        result.Data.Should().Be(default(long));
        await mockRepository.DidNotReceive().Save();
        mockFileService.DidNotReceive().DeleteFile(Arg.Any<string>(), Arg.Any<string>());
    }


  

}


