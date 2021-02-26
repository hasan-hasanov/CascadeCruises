using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adapter.EF.Configurations
{
    public class CruiseReservationConfig : IEntityTypeConfiguration<CruiseReservation>
    {
        public void Configure(EntityTypeBuilder<CruiseReservation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.TravelAgentId)
                .HasColumnName("TravelAgentId");

            builder.Property(x => x.PercentCommissionPerPerson)
                .HasColumnName("PercentCommissionPerPerson");

            builder.Property(x => x.CruiseId)
                .HasColumnName("CruiseId");

            builder.HasOne(x => x.Cruise)
              .WithMany(x => x.CruiseReservations)
              .HasForeignKey(x => x.CruiseId)
              .HasConstraintName("FK_CruiseReservations_Cruises");

            builder.HasOne(x => x.TravelAgent)
             .WithMany(x => x.CruiseReservations)
             .HasForeignKey(x => x.TravelAgentId)
             .HasConstraintName("FK_CruiseReservations_TravelAgents");
        }
    }
}
