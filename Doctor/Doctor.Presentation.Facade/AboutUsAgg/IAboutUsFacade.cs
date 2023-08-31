

using Common.Application;
using Doctor.Application.ContactUsAgg.Create;
using Doctor.Application.ContactUsAgg.Edit;
using Doctor.Query.AboutUsAgg.DTOs;

namespace Doctor.Presentation.Facade.AboutUsAgg;

public interface IAboutUsFacade
{
    Task<OperationResult> Create(Create_ContactUs_Command command);
    Task<OperationResult> Edit(Edit_ContactUs_Command command);
    Task<OperationResult> Remove(long Id);


    Task<AboutUsDto> GetAboutUs();
}
