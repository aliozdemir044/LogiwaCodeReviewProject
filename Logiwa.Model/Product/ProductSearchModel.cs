using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiwa.Model.Product
{
   public class ProductSearchModel
    {
        public string SearchText { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

    }
}
