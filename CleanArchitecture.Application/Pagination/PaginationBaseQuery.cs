﻿namespace CleanArchitecture.Application.Pagination
{
    public class PaginationBaseQuery
    {
        public string? Sort { get; set; }
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 10;

        private const int MaxPageSize = 50;
        public int PageSize 
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}
