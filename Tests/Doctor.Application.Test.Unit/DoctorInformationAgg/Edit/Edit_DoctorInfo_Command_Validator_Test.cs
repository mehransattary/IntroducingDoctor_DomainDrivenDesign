﻿

using Common.Application.FileUtil.Interfaces;
using Doctor.Application.DoctorInformationAgg.Create;
using Doctor.Domain.DoctorInformationAgg;
using Doctor.Domain.DoctorInformationAgg.Repository;
using FluentAssertions;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace Doctor.Application.Test.Unit.DoctorInformationAgg.Edit;

public class Edit_DoctorInfo_Command_Validator_Test
{
    private IDoctorInformationRepository mockRepository;
    private IFileService mockFileService;
    private IFormFile imageFile;

    public Edit_DoctorInfo_Command_Validator_Test()
    {
        mockRepository = Substitute.For<IDoctorInformationRepository>();
        mockFileService = Substitute.For<IFileService>();
        imageFile = Substitute.For<IFormFile>();
    }
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void CreateValidator_Should_Have_Validation_Error_For_Empty_FullName(string invalidTitle)
    {
        // Arrange
        var validator = new Create_DoctorInfo_Command_Validator();
        var command = new Create_DoctorInfo_Command(invalidTitle, imageFile, "", "", "", "",new List<Specialization>());

        // Act
        var result = validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(cmd => cmd.FullName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("test")]
    public void CreateValidator_Should_Have_Validation_Success_For_Fill_FullName(string invalidTitle)
    {
        // Arrange
        var validator = new Create_DoctorInfo_Command_Validator();
        var command = new Create_DoctorInfo_Command(invalidTitle, imageFile, "", "", "", "", new List<Specialization>());

        // Act
        var result = validator.TestValidate(command);

        // Assert
        result.Should().NotBeNull();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("test")]
    public void CreateValidator_Should_Have_Validation_Error_For_NotValid_FileImage(string invalidTitle)
    {
        // Arrange
        var validator = new Create_DoctorInfo_Command_Validator();
        var command = new Create_DoctorInfo_Command(invalidTitle, null, "", "", "", "", new List<Specialization>());

        // Act
        var result = validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(cmd => cmd.FileImage);
    }
}
