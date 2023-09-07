using Common.Query;
using Doctor.Query.UserAgg.DTOs;

namespace Doctor.Query.UserAgg.UserTokens.GetByRefreshToken;

public record GetUserTokenByRefreshTokenQuery(string HashRefreshToken) : IQuery<UserTokenDto?>;