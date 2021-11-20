using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisKebap.DAL.Entities;

namespace MisKebap.DAL.Config
{
    public class CartConfig : IEntityTypeConfiguration<Cart>
    {

        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Amount).IsRequired();
       

            builder.HasOne(p => p.CustomerFK).WithMany(p => p.Carts).HasForeignKey(p => p.CustomerId);
            builder.HasOne(p => p.ExtraFK).WithMany(p => p.Carts).HasForeignKey(p => p.ExtraId);
            builder.HasOne(p => p.SaladTypeFK).WithMany(p => p.Carts).HasForeignKey(p => p.SaladTypeId);
            builder.HasOne(p => p.PortionTypeFK).WithMany(p => p.Carts).HasForeignKey(p => p.PortionTypeId);




        }
    }
}
