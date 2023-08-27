

using Common.Query;

namespace Doctor.Query.ContactUsAgg.DTOs;

public class ContactUsDto : BaseDto
{
    public string Title { get;  set; }
    public string ImageName { get;  set; }
    public string? Description { get;  set; }
}