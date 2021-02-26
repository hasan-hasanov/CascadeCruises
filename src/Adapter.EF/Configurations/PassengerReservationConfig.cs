using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adapter.EF.Configurations
{
    public class PassengerReservationConfig : IEntityTypeConfiguration<PassengerReservation>
    {
        public void Configure(EntityTypeBuilder<PassengerReservation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.PassengerId)
                .HasColumnName("PassengerId");

            builder.Property(x => x.Price)
                .HasColumnName("Price");

            builder.Property(x => x.CabinId)
                .HasColumnName("CabinId");

            builder.Property(x => x.Date)
                .HasColumnName("Date");

            builder.Property(x => x.CruiseId)
                .HasColumnName("CruiseId");

            builder.Property(x => x.TravelAgentId)
                .HasColumnName("TravelAgentId");

            builder.HasOne(x => x.Cabin)
               .WithMany(x => x.PassengerReservations)
               .HasForeignKey(x => x.CabinId)
               .HasConstraintName("FK_PassengerReservations_Cabins");

            builder.HasOne(x => x.Passenger)
               .WithMany(x => x.PassengerReservations)
               .HasForeignKey(x => x.PassengerId)
               .HasConstraintName("FK_PassengerReservations_Passengers");

            builder.HasOne(x => x.Cruise)
               .WithMany(x => x.PassengerReservations)
               .HasForeignKey(x => x.CruiseId)
               .HasConstraintName("FK_PassengerReservations_Cruises");

            builder.HasOne(x => x.TravelAgent)
               .WithMany(x => x.PassengerReservations)
               .HasForeignKey(x => x.TravelAgentId)
               .HasConstraintName("FK_PassengerReservations_TravelAgents");
        }
    }
}
