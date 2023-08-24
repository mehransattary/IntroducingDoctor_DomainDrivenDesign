

using Doctor.Application.MedicalServiceAgg.Create;
using Doctor.Application.MedicalServiceAgg.Edit;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Http;
using Moq;

namespace Doctor.Application.Test.Unit.MedicalServiceAgg.Edit;

public class Edit_MedicalService_Command_ValidatorTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void EditValidator_Should_Have_Validation_Error_For_Empty_Title(string invalidTitle)
    {
        // Arrange
        var validator = new Edit_MedicalService_Command_Validator();
        var command = new Edit_MedicalService_Command(1,invalidTitle, "Test Description", new Mock<IFormFile>().Object);

        // Act
        var result = validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(cmd => cmd.title);
    }
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void EditValidato_Should_Have_Validation_Error_For_Empty_ShortDesc(string input)
    {
        // Arrange
        var validator = new Edit_MedicalService_Command_Validator();
        var command = new Edit_MedicalService_Command(1, "test", input, new Mock<IFormFile>().Object);

        // Act
        var result = validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(cmd => cmd.shortDescription);
    }
    [Theory]
    [InlineData(null)]
    public void EditValidato_Should_Not_Have_Validation_Error_For_Empty_File(IFormFile file)
    {
        // Arrange
        var validator = new Edit_MedicalService_Command_Validator();
        var command = new Edit_MedicalService_Command(1, "test", "Test Description", file);

        // Act
        var result = validator.TestValidate(command);

        // Assert
        result.ShouldNotHaveValidationErrorFor(cmd => cmd.ImageFile);
    }


}
