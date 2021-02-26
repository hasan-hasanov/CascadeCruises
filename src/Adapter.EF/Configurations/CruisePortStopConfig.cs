using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adapter.EF.Configurations
{
    public class CruisePortStopConfig : IEntityTypeConfiguration<CruisePortStop>
    {
        public void Configure(EntityTypeBuilder<CruisePortStop> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.ArrivalDate)
                .HasColumnName("ArrivalDate");

            builder.Property(x => x.DepartureDate)
                .HasColumnName("DepartureDate");

            builder.Property(x => x.CruiseId)
                .HasColumnName("CruiseId");

            builder.Property(x => x.PortId)
                .HasColumnName("PortId");

            builder.HasOne(x => x.Port)
               .WithMany(x => x.CruisePortStops)
               .HasForeignKey(x => x.PortId)
               .HasConstraintName("FK_CruisePortStops_Ports");

            builder.HasOne(x => x.Cruise)
               .WithMany(x => x.CruisePortStops)
               .HasForeignKey(x => x.CruiseId)
               .HasConstraintName("FK_CruisePortStops_Cruises");
        }
    }
}
