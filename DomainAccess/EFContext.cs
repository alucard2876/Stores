using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DomainAccess
{
    public class EFContext :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Order> Orders { get; set; }

        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }
    }
}
