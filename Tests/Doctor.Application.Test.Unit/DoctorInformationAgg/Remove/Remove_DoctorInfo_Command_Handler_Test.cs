

using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Doctor.Application.DoctorInformationAgg.Edit;
using Doctor.Application.DoctorInformationAgg.Remove;
using Doctor.Domain.DoctorInformationAgg;
using Doctor.Domain.DoctorInformationAgg.Repository;
using FluentAssertions;
using Moq;
using NSubstitute;

namespace Doctor.Application.Test.Unit.DoctorInformationAgg.Remove;

public class Remove_DoctorInfo_Command_Handler_Test
{
    private readonly IDoctorInformationRepository _mockRepository;
    private readonly IFileService _mockFileService;

    public Remove_DoctorInfo_Command_Handler_Test()
    {
        _mockRepository =  Substitute.For<IDoctorInformationRepository>();
        _mockFileService = Substitute.For<IFileService>();

    }
    [Fact]
    public async Task Edit_Should_Return_NotFound_When_NotValid()
    {
        //Arrange
         _mockRepository.GetTracking(Arg.Any<long>()).Returns((DoctorInformation)null);
        var handler = new Remove_DoctorInfo_Command_Handler(_mockRepository, _mockFileService);

        var command = new Remove_DoctorInfo_Command(1);
        //Act
        var result = await handler.Handle(command,CancellationToken.None);
        //Assert
        result.Status.Should().Be(OperationResultStatus.NotFound);
    }
    [Fact]
    public async Task Edit_Should_Return_Success_When_Valid()
    {
        var doctorinfo = new DoctorInformation("test", "image", "", "", "", "");
        //Arrange
         _mockRepository.GetTracking(Arg.Any<long>()).Returns(doctorinfo);
         _mockRepository.DeleteDoctorInfo(Arg.Any<long>()).Returns(true);
        var handler = new Remove_DoctorInfo_Command_Handler(_mockRepository, _mockFileService);

        var command = new Remove_DoctorInfo_Command(1);
        //Act
        var result = await handler.Handle(command, CancellationToken.None);
        //Assert
        //await _mockRepository.Received(1).Save();
        result.Status.Should().Be(OperationResultStatus.Success);
    }
}
