using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisKebap.DAL.Entities;

namespace MisKebap.DAL.Config
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.OrderDate).IsRequired();
            builder.Property(p => p.OrderTime).IsRequired();
            builder.Property(p => p.Total).IsRequired();
            builder.Property(p => p.Desc).HasMaxLength(255);
            builder.Property(p => p.OrderStatus).IsRequired();

            builder.HasOne(p => p.CustomerAddressFK).WithMany(p => p.Orders).HasForeignKey(p => p.CustomerAddressId);
            builder.HasOne(p => p.PaymentTypeFK).WithMany(p => p.Orders).HasForeignKey(p => p.PaymentTypeId);
            builder.HasOne(p => p.CustomerFK).WithMany(p => p.Orders).HasForeignKey(p => p.CustomerId);



        }
    }
}
