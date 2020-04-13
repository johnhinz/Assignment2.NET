using CustomerCloud.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerCloud.Repository
{
    public class CustomerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Database=CustomerCloud;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<OrderDetailEntity> OrderDetails { get; set; }
        public DbSet<OrderEntity> Orders { get; set; } 
        public DbSet<ProductEntity> Products { get; set; }
    }
}
