

using Common.Query;
using Doctor.Domain.AboutUsAgg.Services;
using Doctor.Domain.ContactUsAgg.Repository;
using Doctor.Domain.ContactUsAgg.Service;
using Doctor.Query.AboutUsAgg.Mapper;
using Doctor.Query.ContactUsAgg.DTOs;
using Doctor.Query.ContactUsAgg.Mapper;

namespace Doctor.Query.ContactUsAgg.GetById;

public class Get_ContactUs_Query_Handler : IQueryHandler<Get_ContactUs_Query, ContactUsDto>
{
    private readonly IContactUsDomainService _contactUsDomainService;
    public Get_ContactUs_Query_Handler(IContactUsDomainService contactUsDomainService)
    {
        _contactUsDomainService = contactUsDomainService;
    }
    public async Task<ContactUsDto> Handle(Get_ContactUs_Query request, CancellationToken cancellationToken)
    {
      var contactus= await _contactUsDomainService.Get_ContactUs();
        return contactus.Map();
    }
}
