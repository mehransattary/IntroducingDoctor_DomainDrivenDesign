using Doctor.Domain.DoctorInformationAgg;
using Doctor.Domain.MedicalServicesAgg;

namespace Doctor.Domain.Test.Unit.DoctorInformationAgg.Builders;

internal class DoctorInformationBuilder
{
    private string _fullname;
    private string _shortDescription;
    private string _description;
    private string _imagename;
    private string _medicalLicenseNumber;
    private string _email;

    public DoctorInformationBuilder SetFullName(string fullname)
    {
        _fullname = fullname;
        return this;
    }
    public DoctorInformationBuilder SetShortDescription(string shortDescription)
    {
        _shortDescription = shortDescription;
        return this;
    }
    public DoctorInformationBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }
    public DoctorInformationBuilder SetImage(string image)
    {
        _imagename = image;
        return this;
    }
    public DoctorInformationBuilder SetMedicalLicenseNumber(string medicalLicenseNumber)
    {
        _medicalLicenseNumber = medicalLicenseNumber;
        return this;
    }
    public DoctorInformationBuilder SetEmail(string email)
    {
        _email = email;
        return this;
    }
  
    public DoctorInformation Build()
    {
        return new DoctorInformation(_fullname, _imagename, _medicalLicenseNumber, _email, _shortDescription, _description);
    }
}
