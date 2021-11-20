using System;
using System.Collections.Generic;
using MisKebap.Core.Entity;

namespace MisKebap.DAL.Entities
{
    public class PaymentType : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
