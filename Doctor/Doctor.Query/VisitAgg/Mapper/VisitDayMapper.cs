

using Doctor.Domain.DoctorInformationAgg;
using Doctor.Domain.VisitAgg;
using Doctor.Query.DoctorInformationAgg.DTOs;
using Doctor.Query.VisitAgg.DTOs;

namespace Doctor.Query.VisitAgg.Mapper;

public static class VisitDayMapper
{
    public static VisitDayDto Map(this VisitDay? visitDay)
    {
        if (visitDay == null)
            return new VisitDayDto();
        return new VisitDayDto()
        {
            Id= visitDay.Id,    
           Title= visitDay.Title,   
           Day= visitDay.Day,   
           VisitTimes= visitDay.VisitTimes, 
        };
    }
    public static List<VisitDayDto> Map(this List<VisitDay>? visitDays)
    {
        if (visitDays == null)
            return new List<VisitDayDto>();
        var model = new List<VisitDayDto>();
        visitDays.ForEach(x =>
        {
            model.Add(new VisitDayDto()
            {
                Id= x.Id,   
                Title = x.Title,
                Day = x.Day,
                VisitTimes = x.VisitTimes,  
            });
        });
        return model;
    }
}
