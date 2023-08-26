

using Common.Query;
using Doctor.Domain.AboutUsAgg.Repository;
using Doctor.Domain.DoctorInformationAgg.Repository;
using Doctor.Query.AboutUsAgg.DTOs;
using Doctor.Query.AboutUsAgg.Mapper;

namespace Doctor.Query.AboutUsAgg.GetById;

public class Get_AboutUs_Query_Handler : IQueryHandler<Get_AboutUs_Query, AboutUsDto>
{
    private readonly IAboutUsRepository _aboutRepository;
    public Get_AboutUs_Query_Handler(IAboutUsRepository aboutRepository)
    {
        _aboutRepository = aboutRepository;
    }
    public async Task<AboutUsDto> Handle(Get_AboutUs_Query request, CancellationToken cancellationToken)
    {
      var about= await  _aboutRepository.Get_AboutUs();
        return about.Map();
    }
}
