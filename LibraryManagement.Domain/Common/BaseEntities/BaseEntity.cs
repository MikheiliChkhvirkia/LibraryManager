﻿namespace LibraryManagement.Domain.Common.Entities
{
    public abstract class BaseEntity<T>
    {
        /// <summary>
        /// A uniquie identifier.
        /// </summary>
        public T Id { get; set; }
    }
    public abstract class BaseEntity : BaseEntity<int>
    { }
}
