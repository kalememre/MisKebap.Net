using System;
namespace MisKebap.Core.Entity
{
    public class BaseEntity : Audit, ISoftDeleted
    {

        public bool IsDeleted { get; set; } = false;
    }
}
