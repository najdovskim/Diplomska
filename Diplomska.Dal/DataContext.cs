using Diplomska.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;

namespace Diplomska.Dal
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Circuit> Circuits { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            //var circuitNameToIdMap =  context.Circuits.ToDictionaryAsync(c => c.CircuitName, c => c.CircuitId);
        }



        /*  public DataContext(IConfiguration configuration)
            {
                _configuration = configuration;
            }
           protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Default"));
            }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure many-to-many relationship between Driver and Result
            modelBuilder.Entity<Result>()
                .HasKey(r => new { r.DriverId, r.RaceId });

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Driver)
                .WithMany(d => d.Results)
                .HasForeignKey(r => r.DriverId);

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Race)
                .WithMany(ra => ra.Results)
                .HasForeignKey(r => r.RaceId);

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Constructor)
                .WithMany()
                .HasForeignKey(r => r.ConstructorId);

            // configure one-to-many relationship between Race and Circuit
            modelBuilder.Entity<Race>()
                .HasOne(r => r.Circuit)
                .WithMany(c => c.Races)
                .HasForeignKey(r => r.CircuitId);

            // configure one-to-many relationship between DriverStanding and Driver
            modelBuilder.Entity<DriverStanding>()
                .HasOne(ds => ds.Driver)
                .WithMany(d => d.DriverStandings)
                .HasForeignKey(ds => ds.DriverId);

            // configure one-to-many relationship between DriverStanding and Constructor
            modelBuilder.Entity<DriverStanding>()
                .HasOne(ds => ds.Constructor)
                .WithMany(d => d.DriverStandings)
                .HasForeignKey(ds => ds.ConstructorId);

            // configure one-to-many relationship between DriverStanding and Season
            modelBuilder.Entity<DriverStanding>()
                .HasOne(ds => ds.Season)
                .WithMany(s => s.DriverStandings)
                .HasForeignKey(ds => ds.SeasonsId);

            // configure one-to-many relationship between Race and Season
            modelBuilder.Entity<Race>()
                .HasOne(r => r.Season)
                .WithMany(s => s.Races)
                .HasForeignKey(r => r.SeasonId);
        }




        public DbSet<Constructor> Constructors { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverStanding> DriverStandings { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Season> Seasons { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DriverStanding>()
                 .HasOne(ds => ds.Driver)
                 .WithMany(d => d.DriverStandings)
                 .HasForeignKey(ds => ds.DriverId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DriverStanding>()
                .HasOne(ds => ds.Season)
                .WithMany(s => s.DriverStandings)
                .HasForeignKey(ds => ds.SeasonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DriverConstructor>()
                .HasOne(dc => dc.Driver)
                .WithMany(d => d.driverConstructors)
                .HasForeignKey(dc => dc.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DriverConstructor>()
                .HasOne(dc => dc.Constructor)
                .WithMany(c => c.DriverConstructors)
                .HasForeignKey(dc => dc.ConstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Driver)
                .WithMany()
                .HasForeignKey(r => r.DriverId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Constructor)
                .WithMany()
                .HasForeignKey(r => r.ConstructorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Race)
                .WithMany(r => r.Results)
                .HasForeignKey(r => r.RaceId)
                .OnDelete(DeleteBehavior.Restrict);

        }*/


    }

}
