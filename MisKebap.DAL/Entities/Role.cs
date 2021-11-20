using System;
using System.Collections.Generic;
using MisKebap.Core.Entity;

namespace MisKebap.DAL.Entities
{
    public class Role : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CustomerRole> CustomerRoles { get; set; }
    }
}
