using Microsoft.EntityFrameworkCore;
using System;
using TranspoJo.Models;

namespace TranspoJo.Context
{
    public class DbTranspoJo : DbContext
    {
        public DbTranspoJo(DbContextOptions<DbTranspoJo> option) : base(option) { }


        public DbSet<Coordinate> Coordinates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coordinate>(entity =>
            {
                entity.ToTable("Coordinate");

            });
        }
    }
}

  