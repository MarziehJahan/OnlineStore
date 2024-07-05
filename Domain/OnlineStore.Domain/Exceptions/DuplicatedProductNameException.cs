using Framework.Exception;

namespace OnlineStore.Domain.Exceptions
{
    public class DuplicatedProductNameException : BusinessException
    {
        public DuplicatedProductNameException() : base("Product Name Duplicated")
        {
        }
    }
}
