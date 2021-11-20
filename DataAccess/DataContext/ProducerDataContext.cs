using DataAccess.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataContext
{
    public class ProducerDataContext : DbContext
    {
        public ProducerDataContext(DbContextOptions contextOptions) : base(contextOptions)
        {
        }

        DbSet<User> Users { get; set; }
        DbSet<GasNetWork> GasNetWorks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
        }
    }
}
