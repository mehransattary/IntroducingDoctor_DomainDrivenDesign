using Doctor.BlazorWasm.Ui.Models;
using Doctor.BlazorWasm.Ui.Models.Command.Auth;
using Doctor.BlazorWasm.Ui.Models.Response.Auth;

namespace Doctor.BlazorWasm.Ui.Services.Auth;

public interface IAuthService
{
    Task<ApiResult<LoginResponse>?> Login(LoginCommand loginCommand);
    Task<ApiResult> Register(RegisterCommand registerCommand);
    Task<ApiResult> RefreshToken();
    Task<ApiResult> Logout();
}
