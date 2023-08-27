

using Doctor.Domain.ContactUsAgg;
using Doctor.Query.ContactUsAgg.DTOs;

namespace Doctor.Query.ContactUsAgg.Mapper;

public static class ContactUsMapper
{
    public static ContactUsDto Map(this ContactUs? abouteUs)
    {
        if (abouteUs == null)
            return new ContactUsDto();
        return new ContactUsDto()
        {
            Title = abouteUs.Title,   
            ImageName = abouteUs.ImageName,   
            Description = abouteUs.Description,   
        };

    }
   
}
