using System;
using System.Collections.Generic;
using MisKebap.Core.Entity;

namespace MisKebap.DAL.Entities
{
    public class PortionType : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasExtra { get; set; }

        public int PortionId { get; set; }
        public Portion PortionFK { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Cart> Carts { get; set; }



    }
}
