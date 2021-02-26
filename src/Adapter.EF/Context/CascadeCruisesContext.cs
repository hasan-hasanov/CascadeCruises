using Adapter.EF.Configurations;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Adapter.EF.Context
{
    public class CascadeCruisesContext : DbContext
    {
        public CascadeCruisesContext(DbContextOptions<CascadeCruisesContext> options)
            : base(options)
        {
        }

        public DbSet<Cabin> Cabins { get; set; }

        public DbSet<CabinClass> CabinClasses { get; set; }

        public DbSet<Cruise> Cruises { get; set; }

        public DbSet<CruisePortStop> CruisePortStops { get; set; }

        public DbSet<CruiseReservation> CruiseReservations { get; set; }

        public DbSet<Passenger> Passengers { get; set; }

        public DbSet<PassengerReservation> PassengerReservations { get; set; }

        public DbSet<Port> Ports { get; set; }

        public DbSet<Ship> Ships { get; set; }

        public DbSet<TravelAgent> TravelAgents { get; set; }

        public DbSet<CruiseProfit> CruisesProfits { get; set; }

        public DbSet<ShipByMaxRoomsCount> ShipsByMaxRoomsCounts { get; set; }

        public DbSet<ShipInformationWithPorts> ShipsInformationWithPorts { get; set; }

        public DbSet<PassengerAgeAboveSixty> PassengerAgeAboveSixties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CabinClassConfig());
            modelBuilder.ApplyConfiguration(new CabinConfig());
            modelBuilder.ApplyConfiguration(new CruiseConfig());
            modelBuilder.ApplyConfiguration(new CruisePortStopConfig());
            modelBuilder.ApplyConfiguration(new CruiseReservationConfig());
            modelBuilder.ApplyConfiguration(new PassengerConfig());
            modelBuilder.ApplyConfiguration(new PassengerReservationConfig());
            modelBuilder.ApplyConfiguration(new PortConfig());
            modelBuilder.ApplyConfiguration(new ShipConfig());
            modelBuilder.ApplyConfiguration(new TravelAgentConfig());
            modelBuilder.ApplyConfiguration(new CruiseProfitConfig());
            modelBuilder.ApplyConfiguration(new ShipByMaxRoomsCountConfig());
            modelBuilder.ApplyConfiguration(new ShipInformationWithPortsConfig());
            modelBuilder.ApplyConfiguration(new PassengerAgeAboveSixtyConfig());
        }
    }
}
