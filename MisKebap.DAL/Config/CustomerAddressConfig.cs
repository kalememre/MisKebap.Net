using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisKebap.DAL.Entities;

namespace MisKebap.DAL.Config
{
    public class CustomerAddressConfig : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Title).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Street).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Building).HasMaxLength(100).IsRequired();
            builder.Property(p => p.DoorNumber).IsRequired();
            builder.Property(p => p.Spec).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Person).HasMaxLength(100);

            builder.HasOne(p => p.CustomerFK).WithMany(p => p.CustomerAddresses).HasForeignKey(p => p.CustomerId);
            builder.HasOne(p => p.NBHFK).WithMany(p => p.CustomerAddresses).HasForeignKey(p => p.NBHId);

        }
    }
}
