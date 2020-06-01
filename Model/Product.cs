using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Model
{
    class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public double Price { get; set; }
        public double new_Price { get; set; }

        public string Images { get; set; }

        public int StockCount { get; set; }

        public int CategoryId { get; set; }


        public Category Category { get; set; }
    }
}
