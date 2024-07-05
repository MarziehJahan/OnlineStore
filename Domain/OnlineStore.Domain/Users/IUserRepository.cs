namespace OnlineStore.Domain.Users
{
    public interface IUserRepository
    {
        Task<User?> GetBy(long id, CancellationToken cancellationToken);
    }
}
