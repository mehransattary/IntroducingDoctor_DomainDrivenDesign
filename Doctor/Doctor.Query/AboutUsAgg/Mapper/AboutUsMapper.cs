

using Doctor.Domain.AboutUsAgg;
using Doctor.Query.AboutUsAgg.DTOs;

namespace Doctor.Query.AboutUsAgg.Mapper;

public static class AboutUsMapper
{
    public static AboutUsDto Map(this AboutUs? abouteUs)
    {
        if (abouteUs == null)
            return new AboutUsDto();
        return new AboutUsDto()
        {
            Title = abouteUs.Title,   
            ImageName = abouteUs.ImageName,   
            Description = abouteUs.Description,   
        };

    }
   
}
