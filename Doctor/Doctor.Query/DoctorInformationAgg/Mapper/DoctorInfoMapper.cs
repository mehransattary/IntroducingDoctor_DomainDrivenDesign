

using Doctor.Domain.DoctorInformationAgg;
using Doctor.Query.DoctorInformationAgg.DTOs;

namespace Doctor.Query.DoctorInformationAgg.Mapper;

public static class DoctorInfoMapper
{
    public static DoctorInformationDto Map(this DoctorInformation? doctorInfo)
    {
        if (doctorInfo == null)
            return null;
        return new DoctorInformationDto()
        {
            FullName = doctorInfo.FullName,
            ShortDescription = doctorInfo.ShortDescription,
            ImageName = doctorInfo.ImageName,
            Description= doctorInfo.Description,    
            Email= doctorInfo.Email,    
            MedicalLicenseNumber= doctorInfo.MedicalLicenseNumber,  
        };

    }
    public static List<DoctorInformationDto> Map(this List<DoctorInformation> doctorInfos)
    {
        var model = new List<DoctorInformationDto>();
        doctorInfos.ForEach(doctorInfo =>
        {
            model.Add(new DoctorInformationDto() {
                FullName = doctorInfo.FullName,
                ShortDescription = doctorInfo.ShortDescription,
                ImageName = doctorInfo.ImageName,
                Description = doctorInfo.Description,
                Email = doctorInfo.Email,
                MedicalLicenseNumber = doctorInfo.MedicalLicenseNumber,
            });
        });
        return model;
    }
}
