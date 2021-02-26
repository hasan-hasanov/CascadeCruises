using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adapter.EF.Configurations
{
    public class ShipInformationWithPortsConfig : IEntityTypeConfiguration<ShipInformationWithPorts>
    {
        public void Configure(EntityTypeBuilder<ShipInformationWithPorts> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("Id");

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(250);

            builder.Property(x => x.Registry)
                .HasColumnName("Registry")
                .HasMaxLength(250);

            builder.Property(x => x.CreateDate)
                .HasColumnName("CreateDate");

            builder.Property(x => x.FirstClassRoomCount)
                   .HasColumnName("FirstClassRoomCount");

            builder.Property(x => x.SecondClassRoomCount)
                   .HasColumnName("SecondClassRoomCount");

            builder.Property(x => x.ThirdClassRoomCount)
                   .HasColumnName("ThirdClassRoomCount");

            builder.Property(x => x.FirstStopDate)
                   .HasColumnName("FirstStopDate");

            builder.Property(x => x.LastStopDate)
                   .HasColumnName("LasStopDate");

            builder.Property(x => x.PortCity)
                   .HasColumnName("PortCity")
                   .HasMaxLength(250);

            builder.Property(x => x.LastPortCity)
                   .HasColumnName("LastPortCity")
                   .HasMaxLength(250);

            builder.Property(x => x.PassengerCount)
                   .HasColumnName("PassengerCount");
        }
    }
}
