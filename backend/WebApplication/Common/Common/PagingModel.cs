using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PagingModel<T>
    {
        public int TotalCount { set; get; }
        public List<T> Data { set; get; }

        public PagingModel(int totalCount, List<T> data)
        {
            TotalCount = totalCount;
            Data = data;
        }
    }
}
