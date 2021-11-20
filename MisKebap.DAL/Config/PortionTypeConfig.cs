using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisKebap.DAL.Entities;

namespace MisKebap.DAL.Config
{
    public class PortionTypeConfig : IEntityTypeConfiguration<PortionType>
    {
        public void Configure(EntityTypeBuilder<PortionType> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.HasExtra).IsRequired();

            builder.HasOne(p => p.PortionFK).WithMany(p => p.PortionTypes).HasForeignKey(p => p.PortionId);
        }
    }
}
