using System;
using System.Collections.Generic;
using MisKebap.Core.Entity;

namespace MisKebap.DAL.Entities
{
    public class Salad : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Multiple { get; set; }

        public ICollection<SaladType> SaladTypes { get; set; }

    }
}
