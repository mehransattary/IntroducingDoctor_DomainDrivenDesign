﻿

using Doctor.Presentation.Facade.AboutUsAgg;
using Doctor.Presentation.Facade.DoctorInformationAgg;
using Doctor.Presentation.Facade.MedicalServiceAgg;
using Microsoft.Extensions.DependencyInjection;
namespace Doctor.Presentation.Facade;

public static class FacadeBootstrapper
{
    public static void InitFacadeDependency(this IServiceCollection services)
    {
        services.AddScoped<IMedicalServiceFacade, MedicalServiceFacade>();
        services.AddScoped<IDoctorInformationFacade, DoctorInformationFacade>();
        services.AddScoped<IAboutUsFacade, AboutUsFacade>();

    }
}
