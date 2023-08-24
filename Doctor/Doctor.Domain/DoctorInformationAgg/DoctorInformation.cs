
using Common.Domain;
using Common.Domain.Exceptions;
namespace Doctor.Domain.DoctorInformationAgg;

public class DoctorInformation : AggregateRoot
{
    #region Constructors
    public DoctorInformation(string fullName, string image, string medicalLicenseNumber, string email,string shortdesc,string desc)
    {
        Guard(fullName, image);
        FullName = fullName;
        ImageName = image;
        MedicalLicenseNumber = medicalLicenseNumber;
        Email = email;
        ShortDescription = shortdesc;
        Description = desc;

    }

    private DoctorInformation()
    {
    }
    #endregion

    #region Properties
    public string FullName { get; private set; }
    public string ImageName { get; private set; }
    public string? ShortDescription { get; private set; }
    public string? Description { get; private set; }
    public string? MedicalLicenseNumber { get; private set; }
    public string? Email { get; private set; }
    public List<Address> Addresses { get; private set; }
    public List<ContactNumber> ContactNumbers { get; private set; }
    public List<Specialization> Specializatiosn { get; private set; }
    #endregion

    #region Methods
    public void Edit(string fullName, string image, string medicalLicenseNumber, string email, string shortdesc, string desc)
    {
        Guard(fullName, image);
        FullName = fullName;
        ImageName = image;
        MedicalLicenseNumber = medicalLicenseNumber;
        Email = email;
        ShortDescription = shortdesc;
        Description = desc;
    }

    public void SetImage(string image)
    {
        NullOrEmptyDomainDataException.CheckString(image, nameof(image));
        ImageName = image;
    }


    public void SetAddresss(List<Address> addresses)
    {
        addresses.ForEach(s => s.DoctorInformationId = Id);
        Addresses = addresses;
    }
    public void SetContactNumbers(List<ContactNumber> contactNumbers)
    {
        contactNumbers.ForEach(s => s.DoctorInformationId = Id);
        ContactNumbers = contactNumbers;
    }
    public void SetSpecialization(List<Specialization> specializations)
    {
        specializations.ForEach(s => s.DoctorInformationId = Id);
        Specializatiosn = specializations;
    }

    private void Guard(string fullName, string image)
    {
        NullOrEmptyDomainDataException.CheckString(fullName, nameof(fullName));
        NullOrEmptyDomainDataException.CheckString(image, nameof(image));
    }
    #endregion
}


