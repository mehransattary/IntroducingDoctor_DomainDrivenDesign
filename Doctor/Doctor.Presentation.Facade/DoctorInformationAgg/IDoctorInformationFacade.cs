

using Common.Application;
using Doctor.Application.DoctorInformationAgg.AddAddress;
using Doctor.Application.DoctorInformationAgg.AddContactNumber;
using Doctor.Application.DoctorInformationAgg.Create;
using Doctor.Application.DoctorInformationAgg.Edit;
using Doctor.Query.DoctorInformationAgg.DTOs;

namespace Doctor.Presentation.Facade.DoctorInformationAgg;

public interface IDoctorInformationFacade
{
    Task<OperationResult> Create(Create_DoctorInfo_Command command);
    Task<OperationResult> Edit(Edit_DoctorInfo_Command command);
    Task<OperationResult> Remove(long Id);


    Task<DoctorInformationDto> GetById(long medicalServiceId);
    Task<List<DoctorInformationDto>> GetList();

    Task<OperationResult> AddContactNumber(AddContactNumber_DoctorInfo_Command command);
    Task<OperationResult> AddAddress(AddAddress_DoctorInfo_Command command);
}
