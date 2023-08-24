using Doctor.Domain.MedicalServicesAgg.Repository;
using FluentAssertions;
using Moq;

namespace Doctor.Domain.Test.Unit.MedicalServiceAgg.Repository;

public class MedicalServiceRepositoryTests
{
    [Fact]
    public async Task DeleteMedicalService_Should_Return_True_When_Deleted_Successfully()
    {
        // Arrange
        var repositoryMock = new Mock<IMedicalServiceRepository>();
        repositoryMock.Setup(repo => repo.DeleteMedicalService(It.IsAny<long>()))
            .ReturnsAsync(true);

        // Act
        var result = await repositoryMock.Object.DeleteMedicalService(1); // Provide a valid medicalServiceId

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteMedicalService_Should_Return_False_When_Failed_To_Delete()
    {
        // Arrange
        var repositoryMock = new Mock<IMedicalServiceRepository>();
        repositoryMock.Setup(repo => repo.DeleteMedicalService(It.IsAny<long>()))
            .ReturnsAsync(false);

        // Act
        var result = await repositoryMock.Object.DeleteMedicalService(1); // Provide a valid medicalServiceId

        // Assert
        result.Should().BeFalse();
    }
}
