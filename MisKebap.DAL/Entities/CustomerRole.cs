using System;
using MisKebap.Core.Entity;

namespace MisKebap.DAL.Entities
{
    public class CustomerRole : BaseEntity
    {
        public int Id { get; set; }

        public Guid CustomerId { get; set; }
        public Customer CustomerFK { get; set; }

        public int RoleId { get; set; }
        public Role RoleFK { get; set; }
    }
}
