using OnlineStore.Domain.Users;

namespace OnlineStore.Infrastructure.Persistence.EF.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly OnlineStoreDbContext _dbContext;

        public UserRepository(OnlineStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User?> GetBy(long id, CancellationToken cancellationToken)
        => await _dbContext.Users.FindAsync(id, cancellationToken);

    }
}
