using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PagingDataModel<T> where T:class
    {
        /// <summary>
        /// tổng số bản ghi
        /// </summary>
       public int TotalCount { set; get; }

        /// <summary>
        /// kích thước trang
        /// </summary>
       public int PageSize { set; get; }

        /// <summary>
        /// Số trang hiện tại
        /// </summary>
       public int CurrentPageNumber { set; get; }

        /// <summary>
        /// Tổng số trang
        /// </summary>
       public int TotalPages { set; get; }

        /// <summary>
        /// Trang trước
        /// </summary>
       public bool HasPrePage { set; get; }

        /// <summary>
        /// Trang sau
        /// </summary>
       public bool HasNextpage { set; get; }

        /// <summary>
        /// Dữ liệu
        /// </summary>
       public List<T> Data { set; get; }

        public PagingDataModel (int totalCount,List<T> data, int currentPageNumber,int pageSize)
        {
            TotalCount = totalCount;
            Data = data;
            CurrentPageNumber = currentPageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling((double)totalCount / (double)PageSize);
            HasPrePage = CurrentPageNumber > 1;
            HasNextpage = CurrentPageNumber < TotalPages;
        }

    }
}
