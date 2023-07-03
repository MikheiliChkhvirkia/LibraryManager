using System.Diagnostics.CodeAnalysis;

namespace LibraryManagement.Domain.Common.Entities
{   
    public abstract class BaseEntity<T>
    {
        /// <summary>
        /// A uniquie identifier.
        /// </summary>
        public T Id { get; set; }
    }
}
