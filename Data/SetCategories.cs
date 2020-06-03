using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Model;

namespace WPF.Data
{
    class SetCategories
    {
        RestAPI RestAPI;
        ObservableCollection<CategoryModel> Items;

        public SetCategories()
        {

            RestAPI = new RestAPI();

            //AddItems();
        }

        public ObservableCollection<CategoryModel> GetAllItems()
        {
            Items = new ObservableCollection<CategoryModel>();
            RestAPI = new RestAPI();
            List<Category> category = RestAPI.GetCategory();
            if (category == null)
            {
                return Items;
            }
            foreach (var item in category)
            {

                CategoryModel categoryItem = new CategoryModel()
                {
                    Id = item.Id,
                    CategoryName = item.Name,
                    

                };
                Items.Add(categoryItem);



            }
            return Items;
        }

    }
}
