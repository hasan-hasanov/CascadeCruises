using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adapter.EF.Configurations
{
    public class ShipByMaxRoomsCountConfig : IEntityTypeConfiguration<ShipByMaxRoomsCount>
    {
        public void Configure(EntityTypeBuilder<ShipByMaxRoomsCount> builder)
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

            builder.Property(x => x.RoomsCount)
                .HasColumnName("RoomsCount");

            builder.Property(x => x.FirstClassRoomPrice)
                .HasColumnName("FirstClassRoomPrice");

            builder.Property(x => x.SecondClassRoomPrice)
                .HasColumnName("SecondClassRoomPrice");

            builder.Property(x => x.ThirdClassRoomPrice)
                .HasColumnName("ThirdClassRoomPrice");
        }
    }
}
