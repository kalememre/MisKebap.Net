using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisKebap.DAL.Entities;

namespace MisKebap.DAL.Config
{
    public class WriteUsConfig : IEntityTypeConfiguration<WriteUs>
    {
        public void Configure(EntityTypeBuilder<WriteUs> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.NameSurname).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Message).IsRequired().HasMaxLength(100);
            builder.Property(p => p.IsRead).IsRequired();
    }
    }
}
