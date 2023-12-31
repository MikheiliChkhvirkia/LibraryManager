﻿namespace LibraryManagement.Applicaiton.Common
{
    public class PagedData<T>
    {
        public IQueryable<T> Data { get; set; }
        public int TotalItemCount { get; set; }
        public int Page { get; set; }
        public int Offset { get; set; }
        public int PageCount { get; set; }
    }
}