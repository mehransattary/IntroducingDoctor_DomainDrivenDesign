

using Common.Query;

namespace Doctor.Query.AboutUsAgg.DTOs;

public class AboutUsDto : BaseDto
{
    public string Title { get;  set; }
    public string ImageName { get;  set; }
    public string? Description { get;  set; }
}