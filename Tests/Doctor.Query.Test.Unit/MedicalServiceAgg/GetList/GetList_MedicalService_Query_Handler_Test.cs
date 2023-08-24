

using Doctor.Domain.MedicalServicesAgg;
using Doctor.Domain.MedicalServicesAgg.Repository;
using Doctor.Query.MedicalServiceAgg.DTOs;
using Doctor.Query.MedicalServiceAgg.GetById;
using Doctor.Query.MedicalServiceAgg.GetList;
using Moq;

namespace Doctor.Query.Test.Unit.MedicalServiceAgg.GetList;

public class GetList_MedicalService_Query_Handler_Test
{
    [Fact]
    public async Task Handle_ReturnsListOfMedicalServiceDto()
    {
        // Arrange
        var medicalServiceRepositoryMock = new Mock<IMedicalServiceRepository>();
        var nedicalServices = new List<MedicalService>
        {
           new  MedicalService("Title1", "Description1", "image1.jpg"),
           new  MedicalService("Title2", "Description2", "image2.jpg")
        };

        medicalServiceRepositoryMock.Setup(repo => repo.GetList_MedicalService(It.IsAny<CancellationToken>()))
            .ReturnsAsync(nedicalServices);

        var query = new GetList_MedicalService_Query();
        var handler = new GetList_MedicalService_Query_Handler(medicalServiceRepositoryMock.Object);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);

        Assert.Equal("Title1", result[0].Title);
        Assert.Equal("Description1", result[0].ShortDescription);
        Assert.Equal("image1.jpg", result[0].Image);

        Assert.Equal("Title2", result[1].Title);
        Assert.Equal("Description2", result[1].ShortDescription);
        Assert.Equal("image2.jpg", result[1].Image);
    }
}
