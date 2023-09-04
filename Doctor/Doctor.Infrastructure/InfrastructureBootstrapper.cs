

using Doctor.Domain.AboutUsAgg.Repository;
using Doctor.Domain.ContactUsAgg.Repository;
using Doctor.Domain.DoctorInformationAgg.Repository;
using Doctor.Domain.MedicalServicesAgg.Repository;
using Doctor.Domain.VisitAgg.Repository;
using Doctor.Infrastructure.Persistent.Ef;
using Doctor.Infrastructure.Persistent.Ef.AboutUsAgg;
using Doctor.Infrastructure.Persistent.Ef.ContactUsAgg;
using Doctor.Infrastructure.Persistent.Ef.Doctor_Information;
using Doctor.Infrastructure.Persistent.Ef.MedicalServiceAgg;
using Doctor.Infrastructure.Persistent.Ef.Persistent.Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Doctor.Infrastructure.Persistent.Ef.VisitAgg;
namespace Doctor.Infrastructure;

public class InfrastructureBootstrapper
{
    public static void Init(IServiceCollection services,string connectionString)
    {
        services.AddTransient<IMedicalServiceRepository, MedicalServiceRepository>();
        services.AddTransient<IDoctorInformationRepository, DoctorInformationRepository>();
        services.AddTransient<IAboutUsRepository, AboutUsRepository>();
        services.AddTransient<IContactUsRepository, ContactUsRepository>();
        services.AddTransient<IVisitRepository, VisitRepository>();


        services.AddDbContext<DoctorContext>(option =>
        {
            option.UseSqlServer(connectionString);
        });
        services.AddTransient(_ => new DapperContext(connectionString));

    }
}
