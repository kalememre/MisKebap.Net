using System;
using System.Collections.Generic;
using MisKebap.Core.Entity;

namespace MisKebap.DAL.Entities
{
    public class Portion : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public int ProductId { get; set; }
        public Product ProductFK { get; set; }

        public ICollection<PortionType> PortionTypes { get; set; }

    }
}
