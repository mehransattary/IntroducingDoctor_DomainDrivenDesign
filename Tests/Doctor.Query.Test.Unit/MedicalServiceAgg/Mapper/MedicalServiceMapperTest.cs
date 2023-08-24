

using Doctor.Domain.MedicalServicesAgg;
using System.Linq;
using Doctor.Query.MedicalServiceAgg.Mapper;
using NSubstitute;

namespace Doctor.Query.Test.Unit.MedicalServiceAgg.Mapper;

public class MedicalServiceMapperTest
{
    [Fact]
    public void Map_MedicalServiceToMedicalServiceDto_ReturnsCorrectDto()
    {
        // Arrange
       var medicalService= new MedicalService("Title1", "Description1", "image1.jpg");


        // Act
        var medicalServiceDto = medicalService.Map();

        // Assert
        Assert.NotNull(medicalServiceDto);
        Assert.Equal("Title1", medicalServiceDto.Title);
        Assert.Equal("Description1", medicalServiceDto.ShortDescription);
        Assert.Equal("image1.jpg", medicalServiceDto.Image);
    }
    [Fact]
    public void Map_NullMedicalService_ReturnsNullDto()
    {
        // Arrange
        MedicalService medicalService = null;

        // Act
        var medicalServiceDto = medicalService.Map();

        // Assert
        Assert.Null(medicalServiceDto);
    }
    [Fact]
    public void Map_ListOfMedicalServiceToListOfMedicalServiceDto_ReturnsCorrectDtoList()
    {
        // Arrange
        var nedicalServices = new List<MedicalService>
        {
           new  MedicalService("Title1", "Description1", "image1.jpg"),
           new  MedicalService("Title2", "Description2", "image2.jpg")
        };

        // Act
        var medicalServiceDtos = nedicalServices.Map();

        // Assert
        Assert.NotNull(medicalServiceDtos);
        Assert.Equal(2, medicalServiceDtos.Count);

        Assert.Equal("Title1", medicalServiceDtos[0].Title);
        Assert.Equal("Description1", medicalServiceDtos[0].ShortDescription);
        Assert.Equal("image1.jpg", medicalServiceDtos[0].Image);

        Assert.Equal("Title2", medicalServiceDtos[1].Title);
        Assert.Equal("Description2", medicalServiceDtos[1].ShortDescription);
        Assert.Equal("image2.jpg", medicalServiceDtos[1].Image);
    }
}
