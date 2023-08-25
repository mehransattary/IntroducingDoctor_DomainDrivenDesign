

using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Doctor.Application.DoctorInformationAgg.Edit;
using Doctor.Application.MedicalServiceAgg.Edit;
using Doctor.Domain.DoctorInformationAgg;
using Doctor.Domain.DoctorInformationAgg.Repository;
using Doctor.Domain.MedicalServicesAgg;
using Doctor.Domain.MedicalServicesAgg.Repository;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using NSubstitute;

namespace Doctor.Application.Test.Unit.DoctorInformationAgg.Edit;

public class Edit_DoctorInfo_Command_Handler_Test
{
    private readonly IDoctorInformationRepository mockRepository;
    private readonly IFileService mockFileService;
    private IFormFile imageFile;

    public Edit_DoctorInfo_Command_Handler_Test()
    {
        mockRepository = Substitute.For<IDoctorInformationRepository>();
        mockFileService = Substitute.For<IFileService>();
        imageFile = Substitute.For<IFormFile>();
    }

    [Fact]
    public async Task Edit_When_DoctorInfoId_NotValid_Return_NotFound()
    {
        //Arrange
        var doctorinfo = mockRepository.GetTracking(Arg.Any<long>()).Returns((DoctorInformation)null);
        var handler = new Edit_DoctorInfo_Command_Handler(mockRepository, mockFileService);

        var command = new Edit_DoctorInfo_Command(1,"nameTest", imageFile, "", "", "", "");

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        //Assert
        result.Status.Should().Be(OperationResultStatus.NotFound);
    }
    [Fact]
    public async Task Edit_When_DoctorInfoId_Valid_Return_Success()
    {
        //Arrange
        var doctorinfo = new DoctorInformation("test","image","","","","");

        mockRepository.GetTracking(Arg.Any<long>()).Returns(doctorinfo);

        mockFileService.SaveFileAndGenerateName(Arg.Any<IFormFile>(), Arg.Any<string>()).Returns("new_image.jpg");
        mockRepository.DeleteDoctorInfo(Arg.Any<long>()).Returns(true);
        var handler = new Edit_DoctorInfo_Command_Handler(mockRepository, mockFileService);
        var command = new Edit_DoctorInfo_Command(1, "nameTest", imageFile, "", "", "", "");

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        //Assert
        result.Status.Should().Be(OperationResultStatus.Success);
        await mockRepository.Received(1).Save();
    }
}
