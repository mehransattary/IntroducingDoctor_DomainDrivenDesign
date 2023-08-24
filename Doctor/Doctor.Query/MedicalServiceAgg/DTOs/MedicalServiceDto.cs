

using Common.Query;

namespace Doctor.Query.MedicalServiceAgg.DTOs;

public class MedicalServiceDto : BaseDto
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Image { get;  set; }

}
