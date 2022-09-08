using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDomain
{
    public class CustomerFilterModel
    {
        
        public CustomerFilterTypeEnum Type { set; get; }
        public List<CustomerFilterDataModel> Data { set; get; }
    }
}
