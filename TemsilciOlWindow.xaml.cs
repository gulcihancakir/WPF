using System;
using System.Collections.Generic;
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
    /// Interaction logic for TemsilciOlWindow.xaml
    /// </summary>
    public partial class TemsilciOlWindow : Window
    {
        public TemsilciOlWindow()
        {
            InitializeComponent();
        }

        private void temsilci_girisi(object sender, RoutedEventArgs e)
        {

        }

        private void sepet_window_open(object sender, RoutedEventArgs e)
        {

        }

        private void opensearchbox(object sender, RoutedEventArgs e)
        {

        }

        private void opensampuanwindow(object sender, RoutedEventArgs e)
        {
            Sampuan sampuan = new Sampuan();
            this.Visibility = Visibility.Hidden;
            sampuan.Show();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> aylar = new List<string>();
            aylar.Add("Ocak");
            aylar.Add("Şubat");
            aylar.Add("Mart");
            aylar.Add("Nisan");
            aylar.Add("Mayıs");
            aylar.Add("Haziran");
            aylar.Add("Temmuz");
            aylar.Add("Ağustos");
            aylar.Add("Eylül");
            aylar.Add("Ekim");
            aylar.Add("Kasım");
            aylar.Add("Aralık");


            foreach (var item in aylar)
            {
                combobox_ay.Items.Add(item);
            }
            for (int say = 1; say <= 31; say++) combobox_gun.Items.Add(say);
           
            for (int say = 1939; say <= 2002; say++) combobox_yil.Items.Add(say);

            combobox_cinsiyet.Items.Add("Kadın");
            combobox_cinsiyet.Items.Add("Erkek");
        }
    }
}
