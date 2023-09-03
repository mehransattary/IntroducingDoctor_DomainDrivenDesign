

using Common.Application;
using Doctor.Domain.VisitAgg;

namespace Doctor.Application.VisitAgg.Create;

public record Create_VisitDay_Command(string Title, DayEnum day) : IBaseCommand;

