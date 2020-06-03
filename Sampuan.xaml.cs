using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Interaction logic for Sampuan.xaml
    /// </summary>
    public partial class Sampuan : Window
    {
        SetProducts setProducts = new SetProducts();
        bool isMenu4panelopen = false;
        //webAPIEntities data = new webAPIEntities();
        RestAPI restAPI = new RestAPI();
        public Sampuan()
        {
            InitializeComponent();

          
        }
      
        public List<Sepet> Sepet;
        

        private void SepeteEkleButton_Clicked(object sender, RoutedEventArgs e)
        {

            

            Button btnId = e.OriginalSource as Button;
            var mydetails = btnId.DataContext as ProductModel;

            Sepet sepet = new Sepet()
            {
                Images = mydetails.ProductImages,
                Name = mydetails.ProductName,
                Price = mydetails.ProductPrice,
                new_Price = mydetails.ProductNewPrice,
                Count = 2,


            };
            //restAPI.PostSepet(sepet);
            //restAPI.PostSepet(sepet);


            SetSepet setSepet = new SetSepet();
            var deneme = setSepet.GetAllItems();
            foreach (var item in deneme)
            {
                if (item.ProductName == mydetails.ProductName && item.ProductPrice == mydetails.ProductPrice)
                {


                    restAPI.DeleteSepetItem(item.Id);

                }
            }
            restAPI.PostSepet(sepet);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)

        {
           
            listdata.ItemsSource = setProducts.GetAllItems();
            List<string> ml = new List<string>()
            {
                "350 ml","450 ml","500 ml"
            };
            cmb_filter.ItemsSource = ml;
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

        private void SampuanButton_Click(object sender, RoutedEventArgs e)
        {
            Sampuan sampuan = new Sampuan();
            this.Visibility = Visibility.Hidden;
            sampuan.Show();
        }
        private void temsilci_ol(object sender, RoutedEventArgs e)
        {
            TemsilciOlWindow temsilciOlWindow = new TemsilciOlWindow();

            temsilciOlWindow.Show();
        }

        private void open_mainwindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;

            mainWindow.Show();
        }

        private void menu4_click(object sender, RoutedEventArgs e)
        {
            //dispatcherTimer.Start();
            if (isMenu4panelopen)
            {
                dockpanel.Height = 0;
                if (dockpanel.Height == 0)
                {

                    isMenu4panelopen = false;
                }

            }
            else if (!isMenu4panelopen)
            {
                dockpanel.Height = 160;
                if (dockpanel.Height == 160)
                {

                    isMenu4panelopen = true;
                }
            }
        }
        private void ListBoxSampuan_Selected(object sender, RoutedEventArgs e)
        {
            Sampuan sampuan = new Sampuan();
            this.Visibility = Visibility.Hidden;
            sampuan.Show();
        }

        private void listdata_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var mydetails = listdata.SelectedItem as ProductModel;
            DetailWindow detail = new DetailWindow(mydetails,mydetails.ProductName, mydetails.ProductNewPrice, mydetails.ProductPrice, mydetails.ProductContext, mydetails.ProductImages  );
            detail.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var name = cmb_filter.SelectedItem.ToString();
            var data = setProducts.GetFilterProduct(name);
            listdata.ItemsSource = data;
        }
    }
}
   




