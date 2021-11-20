using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisKebap.DAL.Entities;

namespace MisKebap.DAL.Config
{
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Amount).IsRequired();

            builder.HasOne(p => p.OrderFK).WithMany(p => p.OrderDetails).HasForeignKey(p => p.OrderId);
            builder.HasOne(p => p.ExtraFK).WithMany(p => p.OrderDetails).HasForeignKey(p => p.ExtraId);
            builder.HasOne(p => p.SaladTypeFK).WithMany(p => p.OrderDetails).HasForeignKey(p => p.SaladTypeId);

        }
    }
}
