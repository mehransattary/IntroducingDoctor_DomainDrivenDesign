using Common.Application.FileUtil.Interfaces;
using Doctor.Application.MedicalServiceAgg.Create;
using Doctor.Domain.MedicalServicesAgg.Repository;
using FluentAssertions;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;


namespace Doctor.Application.Test.Unit.MedicalServiceAgg.Create;

public class CreateMedicalServiceCommandValidatorTests
{
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void CreateValidator_Should_Have_Validation_Error_For_Empty_Title(string invalidTitle)
    {
        // Arrange
        var validator = new Create_MedicalService_Command_Validator();
        var command = new Create_MedicalService_Command(invalidTitle, "Test Description", new Mock<IFormFile>().Object);

        // Act
        var result = validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(cmd => cmd.title);
    }
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void CreateValidator_Should_Have_Validation_Error_For_Empty_ShortDesc(string invalidShortDesc)
    {
        // Arrange
        var validator = new Create_MedicalService_Command_Validator();
        var command = new Create_MedicalService_Command("test", invalidShortDesc, new Mock<IFormFile>().Object);

        // Act
        var result = validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(cmd => cmd.shortDescription);
    }
    [Theory]
    [InlineData(null)]
    public void CreateValidator_Should_Have_Validation_Error_For_Empty_Image(IFormFile invalidImage)
    {
        // Arrange
        var validator = new Create_MedicalService_Command_Validator();
        var command = new Create_MedicalService_Command("test", "test", invalidImage);

        // Act
        var result = validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(cmd => cmd.ImageFile);
    }
}
