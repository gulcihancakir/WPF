using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Model
{
    public class ProductModel
    {

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductContext { get; set; }
        public double ProductPrice { get; set; }
        public double ProductNewPrice { get; set; }

        public string ProductImages { get; set; }

        public int ProductStockCount { get; set; }
    }
}
