using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MisKebap.DAL.Entities;

namespace MisKebap.DAL.Context
{
    public class MisKebapContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //var connectionString = Environment.GetEnvironmentVariable("MYSQL_URI");
            //optionsBuilder.UseMySQL(connectionString);
            optionsBuilder.UseMySQL("Server=134.122.108.244; Port=3306;Database=mknew;Uid=root;Pwd=mismysql;convert zero datetime=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerRole> CustomerRoles { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<NBH> NBHs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Portion> Portions { get; set; }
        public DbSet<PortionType> PortionTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Salad> Salads { get; set; }
        public DbSet<SaladType> SaladTypes { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<WriteUs> WriteUs { get; set; }




    }
}
