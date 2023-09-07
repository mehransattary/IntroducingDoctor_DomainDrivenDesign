

using Doctor.Presentation.Facade.AboutUsAgg;
using Doctor.Presentation.Facade.ContactUsAgg;
using Doctor.Presentation.Facade.DoctorInformationAgg;
using Doctor.Presentation.Facade.MedicalServiceAgg;
using Doctor.Presentation.Facade.RoleAgg;
using Doctor.Presentation.Facade.UserAgg;
using Doctor.Presentation.Facade.UserAgg.Addresses;
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
        services.AddScoped<IRoleFacade, RoleFacade>();
        services.AddScoped<IUserFacade, UserFacade>();
        services.AddScoped<IUserAddressFacade, UserAddressFacade>();

    }
}
