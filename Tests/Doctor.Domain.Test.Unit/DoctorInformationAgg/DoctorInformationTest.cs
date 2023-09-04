using Common.Domain.Exceptions;
using Doctor.Domain.DoctorInformationAgg;
using Doctor.Domain.Test.Unit.DoctorInformationAgg.Builders;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace Doctor.Domain.Test.Unit.DoctorInformationAgg;

public class DoctorInformationTest
{
    private DoctorInformationBuilder _builder;
    public DoctorInformationTest()
    {
        _builder = new DoctorInformationBuilder();
    }

    [Fact]
    public void Constructor_Should_Create_DoctorInformation_When_Data_Is_Ok()
    {
      
        // Arrange
        _builder.SetFullName("test1")
                .SetShortDescription("s1")
                .SetImage("testimage")
                .SetEmail("m@gmail.com")
                .SetDescription("test")
                .SetMedicalLicenseNumber("");

        // Act
        var docInfo = _builder.Build();

        // Assert
        docInfo.FullName.Should().Be("test1");
        docInfo.ShortDescription.Should().Be("s1");
        docInfo.ImageName.Should().Be("testimage");
        docInfo.Description.Should().Be("test");
        docInfo.Email.Should().Be("m@gmail.com");
        docInfo.MedicalLicenseNumber.Should().Be("");

    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Constructor_Should_Throw_NullOrEmptyDomainDataException_When_Fullname_Is_NullOrEmpty(string fullname)
    {
        // Act & Assert
        Action action = () => _builder.SetFullName(fullname).Build();
        action.Should().ThrowExactly<NullOrEmptyDomainDataException>().WithMessage("FullName is null or empty");
    }

    [Fact]
    public async Task Edit_Should_Update_DoctorInfo_When_Data_Is_Ok()
    {
        // Arrange
        var docInfo = _builder.SetFullName("test1")
                .SetShortDescription("s1")
                .SetImage("testimage")
                .SetEmail("m@gmail.com")
                .SetDescription("test").Build();

        // Act
        docInfo.Edit("mehran","image1","","w","w","w");

        // Assert
        docInfo.FullName.Should().Be("mehran");
        docInfo.ImageName.Should().Be("image1");
        docInfo.MedicalLicenseNumber.Should().Be(""); 

    }
    [Fact]
    public void AddAddresss_Should_Set_Address_Ok()
    {
        // Arrange
        var docInfo = _builder.SetFullName("test1")
                .SetShortDescription("s1")
                .SetImage("testimage")
                .SetEmail("m@gmail.com")
                .SetDescription("test").Build();

        // Act
        var address = new Address(1,"t1", "");

        docInfo.SetAddress(address);

        // Assert
        docInfo.Addresses.Should().Contain(address);


    }
    [Fact]
    public void AddContactNumbers_Should_SetContactNumbers_Ok()
    {
        // Arrange
        var docInfo = _builder.SetFullName("test1")
                .SetShortDescription("s1")
                .SetImage("testimage")
                .SetEmail("m@gmail.com")
                .SetDescription("test").Build();

        // Act
        var contacts = new ContactNumber("09369944780");

        docInfo.SetContactNumber(contacts);
        // Assert
        docInfo.ContactNumbers.Should().Contain(contacts);
    }

    [Fact]
    public void AddSpecialization_Should_SetSpecialization_Ok()
    {
        // Arrange
        var docInfo = _builder.SetFullName("test1")
                .SetShortDescription("s1")
                .SetImage("testimage")
                .SetEmail("m@gmail.com")
                .SetDescription("test").Build();

        // Act
        var specialization = new List<Specialization>()
        {new Specialization("name1"),new Specialization("name2")};

        docInfo.SetSpecialization(specialization);
        // Assert
        docInfo.Specializatiosn.Should().Contain(specialization);
    }
    [Fact]
    public void Add_Image_Should_SetImage_Ok()
    {
        // Arrange
        var docInfo = _builder.SetFullName("test1")
                .SetShortDescription("s1")
                .SetImage("testimage")
                .SetEmail("m@gmail.com")
                .SetDescription("test").Build();

        // Act
        var image = "imagetest";

        docInfo.SetImage(image);
        // Assert
        docInfo.ImageName.Should().Contain(image);
    }
}
