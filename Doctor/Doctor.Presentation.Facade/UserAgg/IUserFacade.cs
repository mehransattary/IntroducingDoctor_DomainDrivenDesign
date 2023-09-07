using Common.Application;
using Doctor.Application.UserAgg.AddToken;
using Doctor.Application.UserAgg.ChangePassword;
using Doctor.Application.UserAgg.Create;
using Doctor.Application.UserAgg.Edit;
using Doctor.Application.UserAgg.Register;
using Doctor.Application.UserAgg.RemoveToken;
using Doctor.Query.UserAgg.DTOs;

namespace Doctor.Presentation.Facade.UserAgg;

public interface IUserFacade
{
    Task<OperationResult> RegisterUser(RegisterUserCommand command);
    Task<OperationResult> EditUser(EditUserCommand command);
    Task<OperationResult> CreateUser(CreateUserCommand command);
    Task<OperationResult> AddToken(AddUserTokenCommand command);
    Task<OperationResult> RemoveToken(RemoveUserTokenCommand command);
    Task<OperationResult> ChangePassword(ChangeUserPasswordCommand command);

    Task<UserDto?> GetUserByPhoneNumber(string phoneNumber);
    Task<UserDto?> GetUserById(long userId);
    Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken);
    Task<UserTokenDto?> GetUserTokenByJwtToken(string jwtToken);
    Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams);
}