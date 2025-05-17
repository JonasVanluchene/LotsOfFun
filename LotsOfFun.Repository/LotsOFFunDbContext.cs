using System;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using LotsOfFun.Model;

using Microsoft.EntityFrameworkCore;

namespace LotsOfFun.Repository
{
    public class LotsOfFunDbContext : DbContext
    {
        public LotsOfFunDbContext(DbContextOptions<LotsOfFunDbContext> options) : base(options)
        {

        }

        public DbSet<Activity> Activities => Set<Activity>();
        public DbSet<Person> People => Set<Person>();
        public DbSet<ActivityRegistration> ActivityRegistrations => Set<ActivityRegistration>();


        /// <summary>
        /// Address does not need to know who owns it so I make clear to DB that a Person or an Activity owns an address
        /// EF will embed the columns inside the table
        ///
        /// I set the precission for Price to ensure EF will create a valid sql type
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Person>().OwnsOne(p => p.Address);
            modelBuilder.Entity<Activity>().OwnsOne(a => a.Address);

            modelBuilder.Entity<Activity>()
                .Property(a => a.Price)
                .HasPrecision(18, 2); // or HasColumnType("decimal(18,2)")
        }

    }
}
