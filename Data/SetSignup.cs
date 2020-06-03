using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Model;

namespace WPF.Data
{
    
    class SetSignup
    {
        RestAPI RestAPI;
        ObservableCollection<SignupModel> Items;
        public SetSignup()
        {

            RestAPI = new RestAPI();

            //AddItems();
        }

        public ObservableCollection<SignupModel> GetAllItems()
        {
            Items = new ObservableCollection<SignupModel>();
            RestAPI = new RestAPI();
            List<Signup> sepet = RestAPI.GetSignup();
            if (sepet == null)
            {
                return Items;
            }
            foreach (var item in sepet)
            {

                SignupModel signupItem = new SignupModel()
                {
                 
                    Name=item.Name,
                    Surname=item.Surname,
                   Adress=item.Adress,
                   Email=item.Email,
                   Parola=item.Parola,
                  

               


                };
                Items.Add(signupItem);



            }
            return Items;
        }
    }
}

