using System;
using System.Collections.Generic;
using MisKebap.Core.Entity;

namespace MisKebap.DAL.Entities
{
    public class CustomerAddress : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public int DoorNumber { get; set; }
        public string Spec { get; set; }
        public string Person { get; set; }

        public int NBHId { get; set; }
        public NBH NBHFK { get; set; }


        public Guid CustomerId { get; set; }
        public Customer CustomerFK { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
