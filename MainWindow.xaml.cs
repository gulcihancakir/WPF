using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int i;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        //private void yeni_cikan_Click(object sender, RoutedEventArgs e)
        //{

           

        //}

        private void goBack(object sender, RoutedEventArgs e)
        {
            i--; // this will decrease 1 from i


            // if the value of i is less than 1
            // then give i the value of 6
            if (i < 1)
            {
                i = 3;
            }
            picHolder.Source = new BitmapImage(new Uri(@"pics/" + i + ".jpg", UriKind.Relative));
        }

        private void goNext(object sender, RoutedEventArgs e)
        {

            i++; // increase i by 1

            // if i's value gets larger than 6 then reset i back to 1

            if (i > 3)
            {
                i = 1;
            }

            // change the picture according to the i's value
            picHolder.Source = new BitmapImage(new Uri(@"pics/" + i + ".jpg", UriKind.Relative));
            Console.WriteLine("hkweşlsözxöcvmbşk");

        }
    }
    }

