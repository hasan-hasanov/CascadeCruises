using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adapter.EF.Configurations
{
    public class CabinClassConfig : IEntityTypeConfiguration<CabinClass>
    {
        public void Configure(EntityTypeBuilder<CabinClass> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Class)
                .HasColumnName("Class")
                .HasMaxLength(250);
        }
    }
}
