

using Common.Query;
using Doctor.Domain.ContactUsAgg.Repository;
using Doctor.Query.AboutUsAgg.Mapper;
using Doctor.Query.ContactUsAgg.DTOs;
using Doctor.Query.ContactUsAgg.Mapper;

namespace Doctor.Query.ContactUsAgg.GetById;

public class Get_ContactUs_Query_Handler : IQueryHandler<Get_ContactUs_Query, ContactUsDto>
{
    private readonly IContactUsRepository _contactRepository;
    public Get_ContactUs_Query_Handler(IContactUsRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }
    public async Task<ContactUsDto> Handle(Get_ContactUs_Query request, CancellationToken cancellationToken)
    {
      var contactus= await _contactRepository.Get_ContactUs();
        return contactus.Map();
    }
}
