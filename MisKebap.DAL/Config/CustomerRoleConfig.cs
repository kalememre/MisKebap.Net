using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisKebap.DAL.Entities;

namespace MisKebap.DAL.Config
{
    public class CustomerRoleConfig : IEntityTypeConfiguration<CustomerRole>
    {
        public void Configure(EntityTypeBuilder<CustomerRole> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.RoleId).IsRequired();

            builder.HasOne(p => p.CustomerFK).WithMany(p => p.CustomerRoles).HasForeignKey(p => p.CustomerId);
            builder.HasOne(p => p.RoleFK).WithMany(p => p.CustomerRoles).HasForeignKey(p => p.RoleId);
        }

    }
}
