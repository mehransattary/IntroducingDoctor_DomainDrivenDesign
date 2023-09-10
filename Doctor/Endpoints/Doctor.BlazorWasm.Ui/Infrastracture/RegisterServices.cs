using Doctor.BlazorWasm.Ui.Services.Auth;
using Doctor.BlazorWasm.Ui.Services.ContactUs;

namespace Doctor.BlazorWasm.Ui.Infrastracture;

public static class RegisterServices
{
    public static IServiceCollection RegisterApiServices(this IServiceCollection services)
    {

        services.AddScoped<IContactUsService, ContactUsService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IContactUsService, ContactUsService>();

        return services;
    }
}
