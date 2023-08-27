

using Common.Application;
using Doctor.Application.ContactUsAgg.Create;
using Doctor.Application.ContactUsAgg.Edit;
using Doctor.Query.ContactUsAgg.DTOs;

namespace Doctor.Presentation.Facade.ContactUsAgg;

public interface IContactUsFacade
{
    Task<OperationResult> Create(Create_ContactUs_Command command);
    Task<OperationResult> Edit(Edit_ContactUs_Command command);
    Task<OperationResult> Remove(long Id);


    Task<ContactUsDto> GetContactUs();
}
