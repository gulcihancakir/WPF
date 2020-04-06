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
    /// Interaction logic for SepetWindow.xaml
    /// </summary>
    public partial class SepetWindow : Window
    {
        public SepetWindow()
        {
            InitializeComponent();
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
    }
}
