using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF.Data;
using WPF.Model;

namespace WPF
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        RestAPI restAPI = new RestAPI();
        public DetailWindow(ProductModel model, string ProductName, double ProductNewPrice, double ProductPrice, string ProductContext, string ProductImages)
        {
            Uri uri = new Uri(ProductImages,UriKind.Absolute);
            ImageSource imageSource = new BitmapImage(uri);

            InitializeComponent();

            MyProductName.Content = ProductName;
            btnId.DataContext = model;
            MyProductNewPrice.Content = ProductNewPrice.ToString() + "TL";
            MyProductPrice.Content = ProductPrice.ToString() + "TL";
            MyProductContext.Text = ProductContext;
            MyImage.Source = imageSource;
            urun_aciklamalari.Text = ProductContext;

        }
        public List<Sepet> Sepet;

        private void SepeteEkleButton_Clicked(object sender, EventArgs e)
        {
            
            var mydetails = btnId.DataContext as ProductModel;
           
            Sepet sepet = new Sepet()
            {
                Images = mydetails.ProductImages,
                Name = mydetails.ProductName,
                Price = mydetails.ProductPrice,
                new_Price = mydetails.ProductNewPrice,
                Count = 2,


            };
            restAPI.PostSepet(sepet);

          

        }
    }
}
