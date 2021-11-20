using System;
using MisKebap.Core.Entity;

namespace MisKebap.DAL.Entities
{
    public class Cart : BaseEntity
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public int PortionTypeId { get; set; }
        public PortionType PortionTypeFK { get; set; }

        public int ExtraId { get; set; }
        public Extra ExtraFK { get; set; }

        public int SaladTypeId { get; set; }
        public SaladType SaladTypeFK { get; set; }

        public Guid CustomerId { get; set; }
        public Customer CustomerFK { get; set; }
    }
}
