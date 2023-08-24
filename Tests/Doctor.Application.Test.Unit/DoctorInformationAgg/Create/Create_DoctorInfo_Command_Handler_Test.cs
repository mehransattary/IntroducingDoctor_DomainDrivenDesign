

using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Doctor.Application.DoctorInformationAgg.Create;
using Doctor.Application.MedicalServiceAgg.Create;
using Doctor.Domain.DoctorInformationAgg.Repository;
using Doctor.Domain.MedicalServicesAgg.Repository;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using NSubstitute;

namespace Doctor.Application.Test.Unit.DoctorInformationAgg.Create;

public class Create_DoctorInfo_Command_Handler_Test
{
    private IDoctorInformationRepository mockRepository;
    private IFileService mockFileService;
    private IFormFile imageFile;

    public Create_DoctorInfo_Command_Handler_Test()
    {
        mockRepository = Substitute.For<IDoctorInformationRepository>();
        mockFileService = Substitute.For<IFileService>();
        imageFile = Substitute.For<IFormFile>();
    }

    [Fact]
    public async Task Create_DoctorInfo_Command_Handler_Should_Return_Error_When_Data_NotValid()
    {

        // Arrange
        var command = new Create_DoctorInfo_Command("nameTest",null,"","","","");
        var handler = new Create_DoctorInfo_Command_Handler(mockRepository, mockFileService);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Status.Should().Be(OperationResultStatus.Error);
    }
    [Fact]
    public async Task Create_DoctorInfo_Command_Handler_Should_Return_Success_When_Data_Valid()
    {
        mockFileService.SaveFileAndGenerateName(Arg.Any<IFormFile>(), Arg.Any<string>()).Returns("new_image.jpg");
        // Arrange
        var command = new Create_DoctorInfo_Command("nameTest", imageFile, "", "", "", "");
        var handler = new Create_DoctorInfo_Command_Handler(mockRepository, mockFileService);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Status.Should().Be(OperationResultStatus.Success);
    }
}
