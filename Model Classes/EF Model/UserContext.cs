using Microsoft.EntityFrameworkCore;
using Model_Classes.EF_Model;
using System;

namespace Model_Classes
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

    }
}
