

using Doctor.Presentation.Facade.AboutUsAgg;
using Doctor.Presentation.Facade.ContactUsAgg;
using Doctor.Presentation.Facade.DoctorInformationAgg;
using Doctor.Presentation.Facade.MedicalServiceAgg;
using Doctor.Presentation.Facade.VisitAgg;
using Microsoft.Extensions.DependencyInjection;
namespace Doctor.Presentation.Facade;

public static class FacadeBootstrapper
{
    public static void InitFacadeDependency(this IServiceCollection services)
    {
        services.AddScoped<IMedicalServiceFacade, MedicalServiceFacade>();
        services.AddScoped<IDoctorInformationFacade, DoctorInformationFacade>();
        services.AddScoped<IAboutUsFacade, AboutUsFacade>();
        services.AddScoped<IContactUsFacade, ContactUsFacade>();
        services.AddScoped<IVisitDayFacade, VisitDayFacade>();

    }
}
