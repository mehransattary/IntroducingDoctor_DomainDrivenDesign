
using Common.Application;
using Doctor.Application.VisitAgg.AddTime;
using Doctor.Application.VisitAgg.Create;
using Doctor.Application.VisitAgg.Edit;
using Doctor.Application.VisitAgg.EditTime;
using Doctor.Query.VisitAgg.DTOs;

namespace Doctor.Presentation.Facade.VisitAgg;

public interface IVisitDayFacade
{
    Task<OperationResult> Create(Create_VisitDay_Command command);
    Task<OperationResult<long>> Edit(Edit_VisitDay_Command command);
    Task<OperationResult> Remove(long visitDayId);
    Task<OperationResult> AddTime(AddTime_Command command);
    Task<OperationResult> EditTime(EditTime_Command command);


    Task<VisitDayDto> GetById(long visitDayId);
    Task<List<VisitDayDto>> GetList();
}
