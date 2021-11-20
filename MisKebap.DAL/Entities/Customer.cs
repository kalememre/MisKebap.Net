using System;
using System.Collections.Generic;
using MisKebap.Core.Entity;

namespace MisKebap.DAL.Entities
{
    public class Customer : BaseEntity
    {
        public Guid Id { get; set; }
        public string NameSurname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool GetEmail { get; set; }
        public bool GetSMS { get; set; }
        public string PushToken { get; set; }

        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public ICollection<CustomerRole> CustomerRoles { get; set; }
        public ICollection<Order> Orders { get; set; }

        public ICollection<Cart> Carts { get; set; }

    }
}
