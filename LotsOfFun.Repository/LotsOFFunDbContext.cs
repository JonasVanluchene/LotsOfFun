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

        public DbSet<Location> Locations => Set<Location>();
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

            modelBuilder.Entity<Person>().OwnsOne(p => p.Address, a =>
            {
                a.Property(p => p.Street).HasColumnName("Street");
                a.Property(p => p.Number).HasColumnName("Number");
                a.Property(p => p.UnitNumber).HasColumnName("UnitNumber");
                a.Property(p => p.PostalCode).HasColumnName("PostalCode");
                a.Property(p => p.City).HasColumnName("City");
            });

            modelBuilder.Entity<Location>().OwnsOne(a => a.Address, a =>
            {
                a.Property(p => p.Street).HasColumnName("Street");
                a.Property(p => p.Number).HasColumnName("Number");
                a.Property(p => p.UnitNumber).HasColumnName("UnitNumber");
                a.Property(p => p.PostalCode).HasColumnName("PostalCode");
                a.Property(p => p.City).HasColumnName("City");
            });

            modelBuilder.Entity<Activity>()
                .Property(a => a.Price)
                .HasPrecision(18, 2); // or HasColumnType("decimal(18,2)")
        }

    }
}
