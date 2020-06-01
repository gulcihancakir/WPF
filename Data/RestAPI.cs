using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WPF.Model;

namespace WPF.Data
{
    class RestAPI
    {
        HttpClient client;

        HttpResponseMessage response;
        public List<Model.Product> Products;
        public List<Sepet> sepet;
        public RestAPI()
        {


            client = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:44363/")
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            GetData();
          
        }


        public List<Model.Product> GetProducts()
        {
            HttpResponseMessage response = client.GetAsync("api/products").Result;
            if (response.IsSuccessStatusCode)
            {
                var items = response.Content.ReadAsAsync<IEnumerable<Model.Product>>().Result;
                Products = items as List<Model.Product>;

            }
            //else
            //{
            //    Application.Current.MainPage.DisplayAlert("Error!", "Error Code" + response.StatusCode +
            //        " : Message -" + response.ReasonPhrase, "Ok");
            //}
            return Products;
        }
        public List<Sepet> GetSepet()
        {
            HttpResponseMessage response = client.GetAsync("api/sepet").Result;
            if (response.IsSuccessStatusCode)
            {
                var items = response.Content.ReadAsAsync<IEnumerable<Sepet>>().Result;
                sepet = items as List<Sepet>;

            }
           
            return sepet;
        }

        public void PostSepet(Sepet sepet)
        {
            string json = JsonConvert.SerializeObject(sepet, Formatting.Indented);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = client.PostAsync("api/sepet", content).Result;
           

           
        }

        public void PostSiparis(Siparis siparis)
        {
            string json = JsonConvert.SerializeObject(siparis, Formatting.Indented);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = client.PostAsync("api/siparis", content).Result;



        }







        private void GetData()
        {
           
            GetProducts();
            GetSepet();



        }

    }
}
