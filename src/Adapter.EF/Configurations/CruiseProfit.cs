using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adapter.EF.Configurations
{
    public class CruiseProfitConfig : IEntityTypeConfiguration<CruiseProfit>
    {
        public void Configure(EntityTypeBuilder<CruiseProfit> builder)
        {
            builder.HasKey(x => x.CruiseName);

            builder.Property(x => x.CruiseName)
                .HasColumnName("CruiseName");

            builder.Property(x => x.PassangerProfit)
                .HasColumnName("PassangerProfit");

            builder.Property(x => x.FuelCost)
                .HasColumnName("FuelCost");

            builder.Property(x => x.Profit)
                .HasColumnName("Profit");
        }
    }
}
