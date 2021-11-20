using System;
using MisKebap.Core.Entity;

namespace MisKebap.DAL.Entities
{
    public class WriteUs : BaseEntity
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }

    }
}
