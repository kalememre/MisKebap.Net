using System;
using System.Collections.Generic;
using MisKebap.Core.Entity;

namespace MisKebap.DAL.Entities
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderTime { get; set; }
        public double Total { get; set; }
        public string Desc { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public bool OrderStatus { get; set; }

        public Guid CustomerId { get; set; }
        public Customer CustomerFK { get; set; }

        public int CustomerAddressId { get; set; }
        public CustomerAddress CustomerAddressFK { get; set; }

        public int PaymentTypeId { get; set; }
        public PaymentType PaymentTypeFK { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }


    }
}
