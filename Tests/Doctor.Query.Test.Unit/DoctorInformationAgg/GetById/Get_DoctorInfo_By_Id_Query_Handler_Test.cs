

using Doctor.Domain.DoctorInformationAgg;
using Doctor.Domain.DoctorInformationAgg.Repository;
using Doctor.Query.DoctorInformationAgg.DTOs;
using Doctor.Query.DoctorInformationAgg.GetById;
using Doctor.Query.DoctorInformationAgg.Mapper;
using FluentAssertions;
using NSubstitute;

namespace Doctor.Query.Test.Unit.DoctorInformationAgg.GetById;

public class Get_DoctorInfo_By_Id_Query_Handler_Test
{
    [Fact]
    public async Task Handle_Should_Return_DoctorInformationDto()
    {
        // Arrange
        var doctorInfoRepositoryMock = Substitute.For<IDoctorInformationRepository>();
        var queryHandler = new Get_DoctorInfo_By_Id_Query_Handler(doctorInfoRepositoryMock);

        var query = new Get_DoctorInfo_By_Id_Query(1);

        var doctorInfoEntity = new DoctorInformation("John Doe", "image.jpg", "12345", "john@example.com", "Short desc", "Description");

        doctorInfoRepositoryMock.Get_DoctorInfo_By_Id(query.doctorInfoId).Returns(doctorInfoEntity);

        // Act
        var result = await queryHandler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.FullName.Should().Be(doctorInfoEntity.FullName);
        result.ShortDescription.Should().Be(doctorInfoEntity.ShortDescription);
        result.ImageName.Should().Be(doctorInfoEntity.ImageName);
        result.Description.Should().Be(doctorInfoEntity.Description);
        result.Email.Should().Be(doctorInfoEntity.Email);
        result.MedicalLicenseNumber.Should().Be(doctorInfoEntity.MedicalLicenseNumber);
    }

    [Fact]
    public void Map_Should_Return_Null_For_Null_Input()
    {
        // Arrange
        DoctorInformation doctorInfo = null;

        // Act
        var result = doctorInfo.Map();

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public void Map_Should_Map_DoctorInformation_To_DoctorInformationDto()
    {
        // Arrange
        var doctorInfo = new DoctorInformation("John Doe", "image.jpg", "12345", "john@example.com", "Short desc", "Description");

        // Act
        var result = doctorInfo.Map();

        // Assert
        result.Should().NotBeNull();
        result.FullName.Should().Be(doctorInfo.FullName);
        result.ShortDescription.Should().Be(doctorInfo.ShortDescription);
        result.ImageName.Should().Be(doctorInfo.ImageName);
        result.Description.Should().Be(doctorInfo.Description);
        result.Email.Should().Be(doctorInfo.Email);
        result.MedicalLicenseNumber.Should().Be(doctorInfo.MedicalLicenseNumber);
    }
}
