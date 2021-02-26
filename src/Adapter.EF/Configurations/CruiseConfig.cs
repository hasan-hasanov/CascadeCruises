using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adapter.EF.Configurations
{
    public class CruiseConfig : IEntityTypeConfiguration<Cruise>
    {
        public void Configure(EntityTypeBuilder<Cruise> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(250);

            builder.Property(x => x.ShipId)
                .HasColumnName("ShipId");

            builder.HasOne(x => x.Ship)
                 .WithMany(x => x.Cruises)
                 .HasForeignKey(x => x.ShipId)
                 .HasConstraintName("FK_Cruises_Ships");
        }
    }
}
