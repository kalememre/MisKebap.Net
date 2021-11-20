using System;
namespace MisKebap.Core.Entity
{
    /// <summary>
    /// DB için silindi mi işareti.
    /// </summary>
    public interface ISoftDeleted
    {
        /// <summary>
        /// Silindi mi?
        /// </summary>
        public bool IsDeleted { get; set; }
    }

}
