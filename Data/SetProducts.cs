using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Model;

namespace WPF.Data
{
    class SetProducts
    {

        //private Page Page;
        RestAPI RestAPI;
        ObservableCollection<ProductModel> Items;

        public SetProducts()
        {

            RestAPI = new RestAPI();

            //AddItems();
        }

        public ObservableCollection<ProductModel> GetAllItems()
        {
            Items = new ObservableCollection<ProductModel>();
            RestAPI = new RestAPI();
            List<Model.Product> products = RestAPI.GetProducts();
            if (products == null)
            {
                return Items;
            }
            foreach (var item in products)
            {

                ProductModel productItem = new ProductModel()
                {
                    Id = item.Id,
                    ProductName = item.Name,
                    ProductPrice = item.Price,
                    ProductNewPrice = item.new_Price,
                    ProductContext = item.Context,
                    ProductStockCount = item.StockCount,
                    ProductImages = item.Images,

                };
                Items.Add(productItem);



            }
            return Items;
        }

        public ObservableCollection<ProductModel> GetFilterProduct(string name)
        {
            Items = new ObservableCollection<ProductModel>();
            RestAPI = new RestAPI();
            int search;

            foreach (var item in RestAPI.GetProducts())
            {
                search = item.Name.IndexOf(name, 0, item.Name.Length);
                if (search == -1)
                {

                }

                else
                {
                    ProductModel productItem = new ProductModel()
                    {
                        Id = item.Id,
                        ProductName = item.Name,
                        ProductPrice = item.Price,
                        ProductNewPrice = item.new_Price,
                        ProductContext = item.Context,
                        ProductStockCount = item.StockCount,
                        ProductImages = item.Images,

                    };
                    Items.Add(productItem);
                }


            }
            return Items;
        }
    }
}

