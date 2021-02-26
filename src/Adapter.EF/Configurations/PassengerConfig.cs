﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adapter.EF.Configurations
{
    public class PassengerConfig : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(250);

            builder.Property(x => x.Surname)
                .HasColumnName("Surname")
                .HasMaxLength(250);

            builder.Property(x => x.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(250);

            builder.Property(x => x.Address)
                .HasColumnName("Address")
                .HasMaxLength(250);

            builder.Property(x => x.PIN)
               .HasColumnName("PIN")
               .HasMaxLength(20);

            builder.Property(x => x.DateOfBirth)
              .HasColumnName("DateOfBirth");
        }
    }
}
