using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
        bool isMenu4panelopen = false;
        webAPIEntities data = new webAPIEntities();

        public Sampuan()
        {
            InitializeComponent();


        }
        private void Create()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44363/");
            //client.DefaultRequestHeaders.Add("appkey", "myapp_key");
            //client.DefaultRequestHeaders.Accept.Add(
            //   new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/products").Result;
            if (response.IsSuccessStatusCode)
            {
                var products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                products.Count();

                Grid grd = new Grid();
                //grd.ShowGridLines = true;



                grd.Width = 900;
                grd.HorizontalAlignment = HorizontalAlignment.Left;
                grd.VerticalAlignment = VerticalAlignment.Top;
                ColumnDefinition col1 = new ColumnDefinition();
                ColumnDefinition col2 = new ColumnDefinition();
                ColumnDefinition col3 = new ColumnDefinition();
                col1.Width = new GridLength(300);
                col2.Width = new GridLength(300);
                col3.Width = new GridLength(300);
              
                RowDefinition row1 = new RowDefinition();
                RowDefinition row2 = new RowDefinition();
                RowDefinition row3 = new RowDefinition();
                RowDefinition row4 = new RowDefinition();
                grd.ColumnDefinitions.Add(col1);
               
                grd.ColumnDefinitions.Add(col2);
                grd.ColumnDefinitions.Add(col3);
                row1.Height = new GridLength(425);
                row2.Height = new GridLength(425);
                row3.Height = new GridLength(425);
                row4.Height = new GridLength(425);
               
                grd.RowDefinitions.Add(row1);
                grd.RowDefinitions.Add(row2);
                grd.RowDefinitions.Add(row3);
                grd.RowDefinitions.Add(row4);
                
                prodPanel.Children.Add(grd);



                var xi = (products.Count() / 3);

                var yi = 0;




                for (int i = 0; i < xi; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        var item = products.ToList()[yi];
                        //var itemm = data2[yi];
                        yi++;

                        Label lbll = new Label();
                        lbll.Content = "_______________________________";
                        lbll.Foreground = Brushes.Orange;
                        lbll.Width = 60;
                        lbll.Height = 150;
                        Grid.SetRow(lbll, i);
                        Grid.SetColumn(lbll, j);
                        grd.Children.Add(lbll);
                        lbll.HorizontalContentAlignment = HorizontalAlignment.Center;
                        lbll.VerticalAlignment = VerticalAlignment.Bottom;
                        Thickness margin6 = lbll.Margin;
                        margin6.Bottom = 40;
                        margin6.Top = 0;
                        margin6.Right = 10;
                        margin6.Left = 10;
                        lbll.Margin = margin6;



                        Image img = new Image();
                        Uri uri = new Uri(item.Images, UriKind.Absolute);
                        ImageSource imgSource = new BitmapImage(uri);
                        img.Source = imgSource;
                        Label lbl = new Label();
                        lbl.Width = 190;
                        lbl.Height = 190;
                        //lbl.Background = Brushes.Black;
                        lbl.Background = new ImageBrush(img.Source);
                        Grid.SetRow(lbl, i);
                        Grid.SetColumn(lbl, j);
                        grd.Children.Add(lbl);
                        lbl.HorizontalContentAlignment = HorizontalAlignment.Center;
                        lbl.VerticalAlignment = VerticalAlignment.Top;
                        Thickness margin5 = lbl.Margin;
                        margin5.Bottom = 10;
                        margin5.Top = 50;
                        margin5.Right = 10;
                        margin5.Left = 10;
                        lbl.Margin = margin5;


                        Label label = new Label();
                        label.Width = 280;
                        label.Height = 50;
                        label.Background = Brushes.Transparent;
                        label.Content = item.Name;



                        var B1 = new Border();
                        B1.BorderBrush = Brushes.Gray;                        
                        B1.BorderThickness = new Thickness(1, 1, 1, 1);
                        Thickness margin4 = B1.Margin;
                        margin4.Bottom = 10;
                        margin4.Top = 10;
                        margin4.Right = 10;
                        margin4.Left = 10;

                        B1.Margin = margin4;



                        Grid.SetRow(B1, i);
                        Grid.SetColumn(B1, j);
                        grd.Children.Add(B1);
                       


                        TextBlock textBlock_price = new TextBlock(new Run(item.Price + "TL" ));
                        textBlock_price.TextDecorations = TextDecorations.Strikethrough;
                        textBlock_price.Foreground = Brushes.Gray;
                        textBlock_price.FontSize = 15;
                        textBlock_price.Width = 60;
                        textBlock_price.Height = 20;
                        textBlock_price.Background = Brushes.White;

                        TextBlock textBlock_newprice = new TextBlock(new Run("-"+item.new_Price + "TL"));
                        textBlock_newprice.FontWeight =FontWeights.Bold;
                        textBlock_newprice.FontSize = 15;
                        textBlock_newprice.Width = 60;
                        textBlock_newprice.Height = 20;
                        textBlock_newprice.Background = Brushes.White;





                        Grid.SetRow(label, i);
                        Grid.SetColumn(label, j);
                        grd.Children.Add(label);
                        label.HorizontalContentAlignment = HorizontalAlignment.Center;
                        label.VerticalAlignment = VerticalAlignment.Bottom;
                        Thickness margin = label.Margin;
                        margin.Bottom = 90;
                        label.Margin = margin;

                        Grid.SetRow(textBlock_price, i);
                        Grid.SetColumn(textBlock_price, j);
                        grd.Children.Add(textBlock_price);
                        textBlock_price.HorizontalAlignment = HorizontalAlignment.Left;
                        textBlock_price.VerticalAlignment = VerticalAlignment.Bottom;
                        Thickness margin1 = textBlock_price.Margin;
                        margin1.Bottom = 80;
                        margin1.Left = 100;
                        textBlock_price.Margin = margin1;

                        Grid.SetRow(textBlock_newprice, i);
                        Grid.SetColumn(textBlock_newprice, j);
                        grd.Children.Add(textBlock_newprice);
                        textBlock_price.HorizontalAlignment = HorizontalAlignment.Left;
                        textBlock_newprice.VerticalAlignment = VerticalAlignment.Bottom;
                        Thickness margin2 = textBlock_newprice.Margin;
                        margin2.Bottom = 80;
                        margin2.Left = 70;
                        textBlock_newprice.Margin = margin2;


                        Button sepeteEklebtn = new Button();
                        sepeteEklebtn.Background = Brushes.Orange;
                        sepeteEklebtn.Content = "Sepete Ekle";
                        sepeteEklebtn.Width = 160;
                        sepeteEklebtn.BorderBrush = Brushes.Orange;
                        sepeteEklebtn.Foreground = Brushes.White;
                        Grid.SetRow(sepeteEklebtn, i);
                        Grid.SetColumn(sepeteEklebtn, j);
                        grd.Children.Add(sepeteEklebtn);
                        sepeteEklebtn.HorizontalAlignment = HorizontalAlignment.Center;
                        sepeteEklebtn.VerticalAlignment = VerticalAlignment.Bottom;
                        Thickness margin3 = textBlock_newprice.Margin;
                        margin3.Bottom = 30;
                        margin3.Right = 60;
                        sepeteEklebtn.Margin = margin3;

                    }
                }


            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)

        {

            Create();

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
   




