using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyChiPhi.Entities
{
    public class PaginationSet<T>
    {
        public int Page { set; get; }
        public int PageSize
        {
            set
            {
                TotalPages = (int)Math.Ceiling((decimal)TotalCount / value);
            }
        }
        public int Count
        {
            get
            {
                return (Items != null) ? Items.Count() : 0;
            }
        }
        public int TotalPages { set; get; }
        public int TotalCount { set; get; }
        public IEnumerable<T> Items { set; get; }
    }
}
