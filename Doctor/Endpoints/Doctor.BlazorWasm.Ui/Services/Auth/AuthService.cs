using Doctor.BlazorWasm.Ui.Models;
using Doctor.BlazorWasm.Ui.Models.Command.Auth;
using Doctor.BlazorWasm.Ui.Models.Response.Auth;
using System.Net.Http.Json;

namespace Doctor.BlazorWasm.Ui.Services.Auth;

public class AuthService: IAuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResult<LoginResponse>?> Login(LoginCommand loginCommand)
    {
        var result = await _httpClient.PostAsJsonAsync("Auth/login", loginCommand);
        return await result.Content.ReadFromJsonAsync<ApiResult<LoginResponse>>();
    }

    public Task<ApiResult> Logout()
    {
        throw new NotImplementedException();
    }

    public Task<ApiResult> RefreshToken()
    {
        throw new NotImplementedException();
    }

    public Task<ApiResult> Register(RegisterCommand registerCommand)
    {
        throw new NotImplementedException();
    }
}
