using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisKebap.DAL.Entities;

namespace MisKebap.DAL.Config
{
    public class AboutUsConfig : IEntityTypeConfiguration<AboutUs>
    {

        public void Configure(EntityTypeBuilder<AboutUs> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Title).IsRequired().HasMaxLength(1000);
            builder.HasData(
                new AboutUs
                {
                    Id = 1,
                    Title = "Hakkımızda"
                });
        }
    }
}
