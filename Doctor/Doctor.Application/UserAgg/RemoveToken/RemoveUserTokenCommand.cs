using Common.Application;

namespace Doctor.Application.UserAgg.RemoveToken;

public record RemoveUserTokenCommand(long UserId, long TokenId) : IBaseCommand<string>;