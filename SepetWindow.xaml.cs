using System;
using System.Collections.Generic;
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
    /// Interaction logic for SepetWindow.xaml
    /// </summary>
    public partial class SepetWindow : Window
    {
        bool isMenu4panelopen = false;
        private int _numValue = 0;
        SetSepet setsepet = new SetSepet();

        RestAPI api = new RestAPI();
        //TextBlock txtNum = new TextBlock();

        public SepetWindow()
        {
            
 
            InitializeComponent();

            listdata.ItemsSource = setsepet.GetAllItems();
      
 

        }

        private void DeleteSepet(object sender, RoutedEventArgs e)
        {
           

            Button btn = e.OriginalSource as Button;
            var data = btn.DataContext as SepetModel;
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:44363/")
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string deleteUri = "api/sepet/" + data.Id.ToString();
            var result = client.DeleteAsync(deleteUri).Result;
            listdata.ItemsSource = setsepet.GetAllItems();

        }

        private void sepeti_temizle(object sender, RoutedEventArgs e)
        {


            //Button btn = e.OriginalSource as Button;
            //var data = btn.DataContext as SepetModel;
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:44363/")
            };
            var data = setsepet.GetAllItems();
            foreach (var item in data)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string deleteUri = "api/sepet/" + item.Id.ToString();
                var result = client.DeleteAsync(deleteUri).Result;
            }
          
            listdata.ItemsSource = setsepet.GetAllItems();

        }

        private void alisverisi_tamamla(object sender, RoutedEventArgs e)
        {
            //    var data = setsepet.GetAllItems();
            //    foreach (var item in data)
            //    {
            //      Images = item.ProductImages,
            //        Name = item.ProductName,
            //     Price = item.ProductPrice,
            //        new_Price = item.ProductNewPrice,
            //        Count = 2,


            //    };
            //api.PostSiparis(siparis);

            //    sepeti_temizle(sender, e);

        }
        public int NumValue
        {
            get { return _numValue; }
            set
            {
                
                _numValue = value;
                //txtNum.Text = value.ToString();
            }
        }

        public void  NumberUpDown()
        {
           
            //txtNum.Text = _numValue.ToString();
            
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            NumValue++;
            
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            NumValue--;
            
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)

        {

            //SetSepet setsepet = new SetSepet();
            //sepetdata.ItemsSource = setsepet.GetAllItems();

        }

        public SepetWindow(ProductModel model, string ProductName, double ProductNewPrice, double ProductPrice, string ProductImages)
        {
            Uri uri = new Uri(ProductImages, UriKind.Absolute);
            ImageSource imageSource = new BitmapImage(uri);

            InitializeComponent();

            //MyProductName.Content = ProductName;
            ////btnId.BindingContext = e.Item;
            //MyProductNewPrice.Content = ProductNewPrice.ToString() + "TL";
            //MyProductPrice.Content = ProductPrice.ToString() + "TL";

            //MyImage.Source = imageSource;
        }

        private void opensampuanwindow(object sender, RoutedEventArgs e)
        {
            Sampuan sampuan = new Sampuan();
            this.Visibility = Visibility.Hidden;
            sampuan.Show();

        }
        private void alisverise_devam_et(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
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
                dockpanel.Height = 140;
                if (dockpanel.Height == 140)
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


    }
}
