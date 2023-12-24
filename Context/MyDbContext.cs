using System;
using System.Reflection;
using WebHomework.Models;
using Microsoft.EntityFrameworkCore;
namespace WebHomework.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
            .HasOne(b => b.user)
            .WithMany(u => u.Books)
            .HasForeignKey(b => b.UserId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
   
    }
}

