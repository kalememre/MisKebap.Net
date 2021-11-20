using System;
using System.Collections.Generic;
using MisKebap.Core.Entity;

namespace MisKebap.DAL.Entities
{
    public class SaladType : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int SaladId { get; set; }
        public Salad SaladFK { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Cart> Carts { get; set; }

    }
}
