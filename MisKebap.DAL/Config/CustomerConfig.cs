using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisKebap.DAL.Entities;

namespace MisKebap.DAL.Config
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.NameSurname).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Phone).HasMaxLength(11).IsFixedLength().IsRequired();
            builder.Property(p => p.Email).HasMaxLength(100);
            builder.Property(p => p.PasswordHash).IsRequired().HasMaxLength(1000);
            builder.Property(p => p.PasswordSalt).IsRequired().HasMaxLength(1000);
            builder.Property(p => p.PushToken).HasMaxLength(1000);
      

        }
    }
}
