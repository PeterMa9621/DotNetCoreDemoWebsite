using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models.User
{
    public class UserContext : DbContext
    {
        public DbSet<UserEntity> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=demo;user=root;password=mjy159357");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(e => e.UserName);
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.Email).IsRequired();
            });
        }
    }
}
