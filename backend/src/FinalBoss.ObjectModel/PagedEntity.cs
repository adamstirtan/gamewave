using System;
using System.Collections.Generic;

namespace FinalBoss.ObjectModel
{
	public class PagedEntity<T> where T : class
	{
        public string Sort { get; set; }

        public bool Ascending { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalItems { get; set; }

        public string NextUrl { get; set; }

        public string PreviousUrl { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}

