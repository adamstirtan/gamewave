using System.Collections.Generic;

namespace FinalBoss.Api.Dto
{
    public class PagedDto<T> where T : class
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalItems { get; set; }

        public string NextUrl { get; set; }

        public string PreviousUrl { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}