using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adapter.EF.Configurations
{
    public class ShipConfig : IEntityTypeConfiguration<Ship>
    {
        public void Configure(EntityTypeBuilder<Ship> builder)
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
        }
    }
}
