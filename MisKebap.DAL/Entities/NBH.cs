using System;
using System.Collections.Generic;
using MisKebap.Core.Entity;

namespace MisKebap.DAL.Entities
{
    public class NBH : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Limit { get; set; }
        public bool IsEnabled { get; set; }

        public ICollection<CustomerAddress> CustomerAddresses { get; set; }

    }
}
