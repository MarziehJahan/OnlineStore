using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineStore.Domain.Orders;
using OnlineStore.Domain.Products;
using OnlineStore.Domain.Users;
using OnlineStore.Infrastructure.Persistence.EF.Products.Configurations;

namespace OnlineStore.Infrastructure.Persistence.EF
{
    public class OnlineStoreDbContext : DbContext
    {
        public DbSet<User?> Users { get; set; }
        public DbSet<Product?> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.development.json", false)
                .Build();
            var connectionString = configuration.GetSection("OnlineStoreConfig").GetSection("ConnectionString").Value;
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options)
            : base(options)
        { }
    }
}
