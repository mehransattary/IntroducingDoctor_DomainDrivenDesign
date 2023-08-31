
using Doctor.Domain.DoctorInformationAgg.Repository;
using Doctor.Domain.DoctorInformationAgg;
using Doctor.Query.DoctorInformationAgg.GetList;
using NSubstitute;
using System.Linq;
using FluentAssertions;
using Doctor.Query.DoctorInformationAgg.Mapper;
using Doctor.Domain.DoctorInformationAgg.Services;

namespace Doctor.Query.Test.Unit.DoctorInformationAgg.GetList;

public class GetList_DoctorInfo_Query_Handler_Test
{
    [Fact]
    public async Task Handle_Should_Return_ListOfDoctorInformationDto()
    {
        // Arrange
        var doctorInfoRepositoryMock = Substitute.For<IDoctorInformationDomianService>();
        var queryHandler = new GetList_DoctorInfo_Query_Handler(doctorInfoRepositoryMock);

        var query = new GetList_DoctorInfo_Query();

        var doctorInfoEntities = new List<DoctorInformation>
            {
                new DoctorInformation("John Doe", "image1.jpg", "12345", "john@example.com", "Short desc 1", "Description 1"),
                new DoctorInformation("Jane Smith", "image2.jpg", "67890", "jane@example.com", "Short desc 2", "Description 2")
            };

        doctorInfoRepositoryMock.Get_List_DoctorInfo().Returns(doctorInfoEntities);

        // Act
        var result = await queryHandler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result[0].FullName.Should().Be(doctorInfoEntities[0].FullName);
        result[1].FullName.Should().Be(doctorInfoEntities[1].FullName);
        // ... other assertions for properties
    }

    [Fact]
    public void MapList_Should_Return_Empty_List_For_Null_Input()
    {
        // Arrange
        List<DoctorInformation> doctorInfoList = null;

        // Act
        var result = doctorInfoList.Map();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Fact]
    public void MapList_Should_Map_ListOfDoctorInformation_To_ListOfDoctorInformationDto()
    {
        // Arrange
        var doctorInfoList = new List<DoctorInformation>
            {
                new DoctorInformation("John Doe", "image1.jpg", "12345", "john@example.com", "Short desc 1", "Description 1"),
                new DoctorInformation("Jane Smith", "image2.jpg", "67890", "jane@example.com", "Short desc 2", "Description 2")
            };

        // Act
        var result = doctorInfoList.Map();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result[0].FullName.Should().Be(doctorInfoList[0].FullName);
        result[1].FullName.Should().Be(doctorInfoList[1].FullName);
        // ... other assertions for properties
    }
}
