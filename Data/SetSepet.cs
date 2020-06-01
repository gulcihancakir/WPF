using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Model;

namespace WPF.Data
{
    class SetSepet
    {
        RestAPI RestAPI;
        ObservableCollection<SepetModel> sepetItems;

        public SetSepet()
        {

            RestAPI = new RestAPI();

            //AddItems();
        }

        public ObservableCollection<SepetModel> GetAllItems()
        {
            sepetItems = new ObservableCollection<SepetModel>();
            RestAPI = new RestAPI();
            List<Sepet> sepet = RestAPI.GetSepet();
            if (sepet == null)
            {
                return sepetItems;
            }
            foreach (var item in sepet)
            {

                SepetModel sepetItem = new SepetModel()
                {
                   Id=item.Id,
                    ProductName = item.Name,
                    ProductPrice = item.Price,
                    ProductNewPrice = item.new_Price,
                  
                    ProductImages = item.Images,

                };
                sepetItems.Add(sepetItem);



            }
            return sepetItems;
        }
    }
}

