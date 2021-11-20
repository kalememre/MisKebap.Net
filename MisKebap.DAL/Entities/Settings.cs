using System;
using MisKebap.Core.Entity;

namespace MisKebap.DAL.Entities
{
    public class Settings : BaseEntity
    {
        public int Id { get; set; }
        public bool IsOpen { get; set; }
        public string Title { get; set; }

    }
}
