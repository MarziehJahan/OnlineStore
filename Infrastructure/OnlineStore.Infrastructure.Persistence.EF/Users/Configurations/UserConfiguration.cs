using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Orders;
using OnlineStore.Domain.Users;

namespace OnlineStore.Infrastructure.Persistence.EF.Users.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.HasMany<Order>(x => x.Orders).WithOne().HasForeignKey(x => x.BuyerId);


            //seed data
            builder.HasData(new User(1, "Ali", new List<Order>()));
            builder.HasData(new User(2, "Bob", new List<Order>()));
            builder.HasData(new User(3, "Sara", new List<Order>()));
            builder.HasData(new User(4, "John", new List<Order>()));
            builder.HasData(new User(5, "Alice", new List<Order>()));
        }
    }
}
