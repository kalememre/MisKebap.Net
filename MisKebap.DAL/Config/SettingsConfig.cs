using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisKebap.DAL.Entities;

namespace MisKebap.DAL.Config
{
    public class SettingsConfig : IEntityTypeConfiguration<Settings>
    {
        public void Configure(EntityTypeBuilder<Settings> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.Property(p => p.IsOpen).IsRequired();
            builder.HasData(
                new Settings
                {
                    Id = 1,
                    Title = "Genel Ayarlar Metin",
                    IsOpen = true
                });

        }
    }
}
