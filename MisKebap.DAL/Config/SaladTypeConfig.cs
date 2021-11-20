using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisKebap.DAL.Entities;

namespace MisKebap.DAL.Config
{
    public class SaladTypeConfig : IEntityTypeConfiguration<SaladType>
    {
        public void Configure(EntityTypeBuilder<SaladType> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(p => p.SaladFK).WithMany(p => p.SaladTypes).HasForeignKey(p => p.SaladId);

        }
    }
}
