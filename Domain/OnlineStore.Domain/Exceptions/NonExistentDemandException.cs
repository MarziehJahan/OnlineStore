using Framework.Exception;

namespace OnlineStore.Domain.Exceptions;

public class NonExistentDemandException : BusinessException
{
    public NonExistentDemandException() : base("Product not charged yet!")
    {
    }
}