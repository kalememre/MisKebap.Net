using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisKebap.DAL.Entities;

namespace MisKebap.DAL.Config
{
    public class PortionConfig : IEntityTypeConfiguration<Portion>
    {
        public void Configure(EntityTypeBuilder<Portion> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).IsRequired();

            builder.HasOne(p => p.ProductFK).WithMany(p => p.Portions).HasForeignKey(p => p.ProductId);
        }
    }
}
