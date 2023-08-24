using Common.Domain.Exceptions;
using Doctor.Domain.Test.Unit.MedicalServiceAgg.Builders;
using FluentAssertions;
using System;

namespace Doctor.Domain.Test.Unit.MedicalServiceAgg;

public class MedicalServiceTest
{
    private MedicalServiceBuilder _builder;
    public MedicalServiceTest()
    {
        _builder = new MedicalServiceBuilder();
    }
    [Fact]
    public void Constructor_Should_Create_MedicalService_When_Data_Is_Ok()
    {
        //arrange
        _builder.SetTitle("test1").SetShortDescription("s1").SetImage("testimage");
        //act
        var medicalService = _builder.Build();
        //act
        medicalService.Title.Should().Be("test1");
        medicalService.ShortDescription.Should().Be("s1");
        medicalService.Image.Should().Be("testimage");

    }
    [Fact]
    public void Constructor_Should_Throw_NullOrEmptyDomainDataException_When_Title_Is_Null()
    {
        //act
        var action1 = new Action(() =>
        {
            _builder.SetTitle("").Build();
        });

        //asserts
        action1.Should().ThrowExactly<NullOrEmptyDomainDataException>().WithMessage("title is null or empty");

    }
    [Fact]
    public void Edit_Should_Update_MedicalService_When_Data_Is_Ok()
    {
        //arrange
        var medicalService = _builder.SetTitle("t1").SetShortDescription("s1").SetImage("image1").Build();

        //act
        medicalService.Edit("t2", "s2", "imag2");

        //asserts
        medicalService.Title.Should().Be("t2");
        medicalService.ShortDescription.Should().Be("s2");
        medicalService.Image.Should().Be("imag2");
    }

    [Fact]
    public void Edit_Should_Throw_NullOrEmptyDomainDataException_When_Title_Is_Null()
    {
        //arrange
        var medicalService = _builder.SetTitle("t1").SetShortDescription("s1").SetImage("image1").Build();

        //act
        var action = () =>
        {
            medicalService.Edit("", "s2", "imag2");
        };

        //asserts
        action.Should().ThrowExactly<NullOrEmptyDomainDataException>().WithMessage("title is null or empty");

    }


}