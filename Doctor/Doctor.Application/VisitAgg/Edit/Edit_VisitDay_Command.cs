

using Common.Application;
using Doctor.Domain.VisitAgg;

namespace Doctor.Application.VisitAgg.Edit;


public record Edit_VisitDay_Command(long Id,string Title, DayEnum day) : IBaseCommand;
