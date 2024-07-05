namespace OnlineStore.Domain.Services
{
    public interface IProductDomainService
    {
        Task<bool> TitleIsDuplicate(string title);
    }
}
