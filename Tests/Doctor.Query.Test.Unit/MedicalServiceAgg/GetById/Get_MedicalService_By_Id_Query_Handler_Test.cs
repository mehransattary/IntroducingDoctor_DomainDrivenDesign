

using Doctor.Domain.MedicalServicesAgg;
using Doctor.Domain.MedicalServicesAgg.Repository;
using Doctor.Infrastructure.Persistent.Ef;
using Doctor.Query.MedicalServiceAgg.DTOs;
using Doctor.Query.MedicalServiceAgg.GetById;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NSubstitute;
using System.Linq.Expressions;

namespace Doctor.Query.Test.Unit.MedicalServiceAgg.GetById;

public class Get_MedicalService_By_Id_Query_Handler_Test
{
   
    [Fact]
    public async Task Handle_ValidId_ReturnsMedicalServiceDto()
    {
        var medicalServiceRepositoryMock = new Mock<IMedicalServiceRepository>();

        // Arrange
        var medicalService = new MedicalService("Title1", "Description1", "image1.jpg");
       

        medicalServiceRepositoryMock.Setup(repo => repo.Get_MedicalService_By_Id(It.IsAny<long>(), CancellationToken.None))
          .ReturnsAsync(medicalService);


        var query = new Get_MedicalService_By_Id_Query(1);
        var handler = new Get_MedicalService_By_Id_Query_Handler(medicalServiceRepositoryMock.Object);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Title.Should().Be("Title1");
        result.ShortDescription.Should().Be("Description1");
        result.Image.Should().Be("image1.jpg");

    }

}

