using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace WPF
{
    /// <summary>
    /// Interaction logic for Sampuan.xaml
    /// </summary>
    public partial class Sampuan : Window
    {

        webAPIEntities data = new webAPIEntities();

        public Sampuan()
        {
            InitializeComponent();


            List<Product> urun = new List<Product>();
            
            //using (var contxt = new webAPIEntities())
            //{

                

            //    foreach (var i in urun)
            //    {
            //        urun.Add(new Product() { Name = i.Name ,Context = i.Context, Images = i.Images });
            //    }
                //DTGridEmp.ItemsSource = urun;
               
            
                //  DTGridEmp.ItemsSource = items;

            }

        private void Create()
        {
            List<Product> products = data.Products.OrderBy(x => x.Name).ToList();
            List<Product> products1 = (from a in data.Products.ToList()
                                       select new Product
                                       {
                                           Name = a.Name

                                       }
           ).ToList();

        }

        private void sepet_window_open(object sender, RoutedEventArgs e)
        {
            SepetWindow sepetWindow = new SepetWindow();
            this.Visibility = Visibility.Hidden;
            sepetWindow.Show();
        }

        private void temsilci_girisi(object sender, RoutedEventArgs e)
        {
            TemsilciGirisi temsilciGirisi = new TemsilciGirisi();

            temsilciGirisi.Show();
        }
    }
   


}

