using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using UrbanShop.Controllers;
using UrbanShop.Models;

namespace UrbanShop.Data
{
    public class AppDbContext : DbContext
    {
        //AppDbContext
        private readonly AppDbContext _context;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Account> Account { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
}
