using Common.Application;
using Common.Application.SecurityUtil;
using Doctor.Application.UserAgg.AddToken;
using Doctor.Application.UserAgg.ChangePassword;
using Doctor.Application.UserAgg.Create;
using Doctor.Application.UserAgg.Edit;
using Doctor.Application.UserAgg.Register;
using Doctor.Application.UserAgg.RemoveToken;
using Doctor.Query.UserAgg.DTOs;
using Doctor.Query.UserAgg.GetByFilter;
using Doctor.Query.UserAgg.GetById;
using Doctor.Query.UserAgg.GetByPhoneNumber;
using Doctor.Query.UserAgg.UserTokens.GetByJwtToken;
using Doctor.Query.UserAgg.UserTokens.GetByRefreshToken;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;


namespace Doctor.Presentation.Facade.UserAgg;

internal class UserFacade : IUserFacade
{
    private readonly IMediator _mediator;
    private IDistributedCache _cache;
    public UserFacade(IMediator mediator, IDistributedCache cache)
    {
        _mediator = mediator;
        _cache = cache;
    }


    public async Task<OperationResult> CreateUser(CreateUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> AddToken(AddUserTokenCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> RemoveToken(RemoveUserTokenCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.Status != OperationResultStatus.Success)
            return OperationResult.Error();

       // await _cache.RemoveAsync(CacheKeys.UserToken(result.Data));
        return OperationResult.Success();
    }

    public async Task<OperationResult> ChangePassword(ChangeUserPasswordCommand command)
    {
       // await _cache.RemoveAsync(CacheKeys.User(command.UserId));
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditUser(EditUserCommand command)
    {
        var result = await _mediator.Send(command);
       // if (result.Status == OperationResultStatus.Success)
          //  await _cache.RemoveAsync(CacheKeys.User(command.UserId));
        return result;
    }

    public async Task<UserDto?> GetUserById(long userId)
    {
        //return await _cache.GetOrSet(CacheKeys.User(userId), () =>
        //{
        //    return _mediator.Send(new GetUserByIdQuery(userId));
        //});

        return await _mediator.Send(new GetUserByIdQuery(userId));

    }

    public async Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken)
    {
        var hashRefreshToken = Sha256Hasher.Hash(refreshToken);
        return await _mediator.Send(new GetUserTokenByRefreshTokenQuery(hashRefreshToken));
    }

    public async Task<UserTokenDto?> GetUserTokenByJwtToken(string jwtToken)
    {
        var hashJwtToken = Sha256Hasher.Hash(jwtToken);
        //return await _cache.GetOrSet(CacheKeys.UserToken(hashJwtToken), () =>
        //{
        //    return _mediator.Send(new GetUserTokenByJwtTokenQuery(hashJwtToken));
        //});

        return await _mediator.Send(new GetUserTokenByJwtTokenQuery(hashJwtToken));

    }

    public async Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams)
    {
        return await _mediator.Send(new GetUserByFilterQuery(filterParams));
    }

    public async Task<UserDto?> GetUserByPhoneNumber(string phoneNumber)
    {
        return await _mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));
    }

    public async Task<OperationResult> RegisterUser(RegisterUserCommand command)
    {
        return await _mediator.Send(command);
    }
}