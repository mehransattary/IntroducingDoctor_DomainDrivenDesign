
using Common.Application;
using Doctor.Application.DoctorInformationAgg.Remove;
using FluentValidation.Validators;

namespace Doctor.Application.ContactUsAgg.Remove;

public record Remove_ContactUs_Command(long Id):IBaseCommand;
