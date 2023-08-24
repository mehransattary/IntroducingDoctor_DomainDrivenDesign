
using Common.Query;

namespace Doctor.Query.DoctorInformationAgg.DTOs;

public class DoctorInformationDto : BaseDto
{
    public string FullName { get;  set; }
    public string ImageName { get;  set; }
    public string? ShortDescription { get;  set; }
    public string? Description { get;  set; }
    public string? MedicalLicenseNumber { get;  set; }
    public string? Email { get;  set; }
}
