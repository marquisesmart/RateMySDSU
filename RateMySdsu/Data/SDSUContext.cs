using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RateMySdsu.Models;
using Microsoft.EntityFrameworkCore;

namespace RateMySdsu.Data
{
    public class SDSUContext : DbContext
    {
        public SDSUContext(DbContextOptions<SDSUContext> options) : base(options)
        {
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>().ToTable("Class");
            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<Student>().ToTable("Student");
        }

    }
}
