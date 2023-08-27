

using Common.Application;
using Doctor.Application.AboutUsAgg.Create;
using Doctor.Application.AboutUsAgg.Edit;
using Doctor.Application.DoctorInformationAgg.Create;
using Doctor.Application.DoctorInformationAgg.Edit;
using Doctor.Query.AboutUsAgg.DTOs;
using Doctor.Query.DoctorInformationAgg.DTOs;

namespace Doctor.Presentation.Facade.AboutUsAgg;

public interface IAboutUsFacade
{
    Task<OperationResult> Create(Create_ContactUs_Command command);
    Task<OperationResult> Edit(Edit_ContactUs_Command command);
    Task<OperationResult> Remove(long Id);


    Task<AboutUsDto> GetAboutUs();
}
