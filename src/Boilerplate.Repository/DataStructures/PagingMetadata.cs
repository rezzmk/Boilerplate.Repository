using System;

namespace Boilerplate.Repository.DataStructures {
    public class PagingMetadata {
        public int CurrentPage { get; }
        public int TotalPages { get; }
        public int PageSize { get; }
        public int TotalCount { get; }

        public PagingMetadata(int count, int pageSize, int pageNumber) {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int) Math.Ceiling(count / (double) pageSize);
        }
    }
}