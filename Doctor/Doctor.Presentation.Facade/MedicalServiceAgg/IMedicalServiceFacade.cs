using Common.Application;
using Doctor.Application.MedicalServiceAgg.Create;
using Doctor.Application.MedicalServiceAgg.Edit;
using Doctor.Query.MedicalServiceAgg.DTOs;

namespace Doctor.Presentation.Facade.MedicalServiceAgg;

public interface IMedicalServiceFacade
{
    Task<OperationResult> Create(Create_MedicalService_Command command);
    Task<OperationResult<long>> Edit(Edit_MedicalService_Command command);
    Task<OperationResult> Remove(long medicalServiceId);


    Task<MedicalServiceDto> GetById(long medicalServiceId);
    Task<List<MedicalServiceDto>> GetList();


}
