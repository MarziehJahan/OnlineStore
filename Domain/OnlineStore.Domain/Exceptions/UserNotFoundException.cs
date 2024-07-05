using Framework.Exception;

namespace OnlineStore.Domain.Exceptions;

public class UserNotFoundException : BusinessException
{
    public UserNotFoundException() : base("User not found!")
    {
    }
}