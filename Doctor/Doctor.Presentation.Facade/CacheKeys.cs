namespace Doctor.Presentation.Facade;

class CacheKeys
{
    public static string User(long id) => $"user-{id}";
    public static string UserToken(string hashToken) => $"tok-{hashToken}";
}