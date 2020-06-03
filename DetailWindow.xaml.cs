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
using System.Windows.Media.Animation;
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
        bool isMenu4panelopen = false;
        public DetailWindow(ProductModel model, string ProductName, double ProductNewPrice, double ProductPrice, string ProductContext, string ProductImages)
        {
            Uri uri = new Uri(ProductImages,UriKind.Absolute);
            ImageSource imageSource = new BitmapImage(uri);

            InitializeComponent();

            MyProductName.Content = ProductName;
            btnId.DataContext = model;
            MyProductNewPrice.Text = ProductNewPrice.ToString() + "TL";
            MyProductPrice.Text = ProductPrice.ToString() + "TL";
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
            //restAPI.PostSepet(sepet);


            SetSepet setSepet = new SetSepet();
                var deneme = setSepet.GetAllItems();
                foreach (var item in deneme)
                {
                    if (item.ProductName == mydetails.ProductName && item.ProductPrice==mydetails.ProductPrice)
                    {


                    restAPI.DeleteSepetItem(item.Id);

                    }
                }
            restAPI.PostSepet(sepet);
            //listsepet.ItemsSource = setSepet.GetAllItems();
           

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)

        {

           
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

        private void temsilci_ol(object sender, RoutedEventArgs e)
        {
            TemsilciOlWindow temsilciOlWindow = new TemsilciOlWindow();

            temsilciOlWindow.Show();
        }

        private int currentElement = 0;

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            if (currentElement < 2)
            {
                currentElement++;
                AnimateCarousel();
            }
        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {
            if (currentElement > 0)
            {
                currentElement--;
                AnimateCarousel();
            }
        }

        private void AnimateCarousel()
        {
            SetProducts setProducts = new SetProducts();
            Carousel.DataContext = setProducts.GetAllItems();
            Storyboard storyboard = (this.Resources["CarouselStoryboard"] as Storyboard);
            DoubleAnimation animation = storyboard.Children.First() as DoubleAnimation;
            animation.To = -this.Width * currentElement;
            storyboard.Begin();
        }
    }
}
