using System;
using System.Collections.Generic;
using MisKebap.Core.Entity;

namespace MisKebap.DAL.Entities
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsEnabled { get; set; }

        public int CategoryId { get; set; }
        public Category CategoryFK { get; set; }

        public ICollection<Portion> Portions { get; set; }

    }
}
