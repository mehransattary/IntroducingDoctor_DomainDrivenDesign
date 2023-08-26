
using Common.Application;
using Doctor.Application.DoctorInformationAgg.Remove;
using FluentValidation.Validators;

namespace Doctor.Application.AboutUsAgg.Remove;

public record Remove_AboutUs_Command(long Id):IBaseCommand;
