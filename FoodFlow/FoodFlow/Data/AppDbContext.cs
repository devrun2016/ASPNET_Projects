﻿using FoodFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodFlow.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Tables
        public DbSet<Account> Account { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Account)
                .WithMany(a => a.Users)
                .HasForeignKey(u => u.Account_ID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
