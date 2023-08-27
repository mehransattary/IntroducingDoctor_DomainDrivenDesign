using Doctor.Domain.MedicalServicesAgg.Services;
using Doctor.Infrastructure;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Doctor.Presentation.Facade;
using MediatR;
using Doctor.Query.MedicalServiceAgg.GetList;
using Doctor.Application.MedicalServiceAgg.Create;
using Doctor.Application.MedicalServiceAgg.Services;
using Doctor.Application._Utilities;
using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using Doctor.Domain.DoctorInformationAgg.Services;
using Doctor.Application.DoctorInformationAgg.Service;
using Doctor.Domain.AboutUsAgg.Services;
using Doctor.Application.AboutUsAgg.Service;
using Doctor.Domain.ContactUsAgg.Service;
using Doctor.Application.ContactUsAgg.Service;

namespace Doctor.Config;

public static class DoctorBootstrapper
{
    public static void RegisterDocotrDependency(this IServiceCollection services , string connectionString)
    {
        InfrastructureBootstrapper.Init(services, connectionString);
        services.AddMediatR(typeof(Directories).Assembly);
        services.AddMediatR(typeof(Create_MedicalService_Command).Assembly);
        services.AddMediatR(typeof(GetList_MedicalService_Query).Assembly);
        services.AddTransient<IFileService, FileService>();

        services.AddTransient<IMedicalServicesDomianService, MedicalServicesDomianService>();
        services.AddTransient<IDoctorInformationDomianService, DoctorInformationDomianService>();
        services.AddTransient<IAboutDomainService, AboutDomainService>();
        services.AddTransient<IContactUsDomainService, ContactUsDomainService>();

        services.AddValidatorsFromAssembly(typeof(Create_MedicalService_Command_Validator).Assembly);
        services.InitFacadeDependency();

    }
}
