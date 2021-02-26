using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adapter.EF.Configurations
{
    public class CabinConfig : IEntityTypeConfiguration<Cabin>
    {
        public void Configure(EntityTypeBuilder<Cabin> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.MaxNumberOfPeople)
                .HasColumnName("MaxNumberOfPeople");

            builder.Property(x => x.ShipId)
                .HasColumnName("ShipId");

            builder.Property(x => x.ClassId)
                .HasColumnName("ClassId");

            builder.Property(x => x.Number)
                .HasColumnName("Number");

            builder.Property(x => x.MaxPrice)
                .HasColumnName("MaxPrice");

            builder.HasOne(x => x.Ship)
                .WithMany(x => x.Cabins)
                .HasForeignKey(x => x.ShipId)
                .HasConstraintName("FK_Cabins_Ships");

            builder.HasOne(x => x.CabinClass)
                .WithMany(x => x.Cabins)
                .HasForeignKey(x => x.ClassId)
                .HasConstraintName("FK_Cabins_CabinClasses");
        }
    }
}
