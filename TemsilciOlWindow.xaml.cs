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
using WPF.Data;
using WPF.Model;

namespace WPF
{
    /// <summary>
    /// Interaction logic for TemsilciOlWindow.xaml
    /// </summary>
    /// 

    public partial class TemsilciOlWindow : Window
    {

        RestAPI restAPI = new RestAPI();
        bool isMenu4panelopen = false;

        public TemsilciOlWindow()
        {
            InitializeComponent();
        }

        private void temsilci_girisi(object sender, RoutedEventArgs e)
        {
            TemsilciGirisi temsilciGirisi = new TemsilciGirisi();

            temsilciGirisi.Show();
        }

        private void kayit_ol(object sender, RoutedEventArgs e)
        {
            Signup signup = new Signup()
            {
                Name = UserName.Text,
                Surname = UserSurname.Text,
                Email = UserEmail.Text,
                Adress = UserAdress.Text,
                Phone_Number = UserPhone.Text,
                Parola = UserParola.Password,


        };
            restAPI.Signup(signup);

        }

        private void sepet_window_open(object sender, RoutedEventArgs e)
        {
            SepetWindow sepetWindow = new SepetWindow();
            this.Visibility = Visibility.Hidden;
            sepetWindow.Show();
        }

        private void opensearchbox(object sender, RoutedEventArgs e)
        {

        }

        //private void opensampuanwindow(object sender, RoutedEventArgs e)
        //{
        //    Sampuan sampuan = new Sampuan();
        //    this.Visibility = Visibility.Hidden;
        //    sampuan.Show();

        //}

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

        private void open_mainwindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;

            mainWindow.Show();
        }

        private void ListBoxSampuan_Selected(object sender, RoutedEventArgs e)
        {
            Sampuan sampuan = new Sampuan();
            this.Visibility = Visibility.Hidden;
            sampuan.Show();
        }

        private void menu4_click(object sender, RoutedEventArgs e)
        {
            
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

    }
}
