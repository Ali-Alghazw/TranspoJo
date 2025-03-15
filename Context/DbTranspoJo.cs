using Microsoft.EntityFrameworkCore;
using System;

namespace TranspoJo.Context
{
    public class DbTranspoJo : DbContext
    {
        public DbTranspoJo(DbContextOptions<DbTranspoJo> option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
        }
    }
}
