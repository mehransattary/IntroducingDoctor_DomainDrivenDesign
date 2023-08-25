using Doctor.Domain.MedicalServicesAgg;
using Doctor.Query.MedicalServiceAgg.DTOs;
namespace Doctor.Query.MedicalServiceAgg.Mapper;

public static class MedicalServiceMapper
{
    public static MedicalServiceDto Map(this MedicalService? medicalService)
    {
        if (medicalService == null)
            return new MedicalServiceDto();
        return new MedicalServiceDto()
        {
            Title=medicalService.Title,
            ShortDescription=medicalService.ShortDescription,
            Image=medicalService.Image,
        };

    }
    public static List<MedicalServiceDto> Map(this List<MedicalService> medicalServices)
    {
        if (medicalServices == null)
            return new List<MedicalServiceDto>();
        var model = new List<MedicalServiceDto>();
        medicalServices.ForEach(x => {
            model.Add(new MedicalServiceDto() { Title=x.Title,ShortDescription=x.ShortDescription,Image=x.Image});
        });
        return model;
    }
}
