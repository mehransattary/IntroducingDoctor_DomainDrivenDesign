
using Common.Query;
using Doctor.Domain.DoctorInformationAgg;

namespace Doctor.Query.DoctorInformationAgg.DTOs;

public class DoctorInformationDto : BaseDto
{
    public string FullName { get;  set; }
    public string ImageName { get;  set; }
    public string? ShortDescription { get;  set; }
    public string? Description { get;  set; }
    public string? MedicalLicenseNumber { get;  set; }
    public string? Email { get;  set; }
    public List<Address>? Addresses { get;  set; }
    public List<ContactNumber>? ContactNumbers { get;  set; }
    public List<Specialization>? Specializatiosn { get;  set; }
}
