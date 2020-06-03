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
using System.Windows.Media.Animation;
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
        bool isMenu4panelopen = false;

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
            i--; 


           
            if (i < 1)
            {
                i = 3;
            }
            picHolder.Source = new BitmapImage(new Uri(@"pics/" + i + ".PNG", UriKind.Relative));
        }

        private void goNext(object sender, RoutedEventArgs e)
        {

            i++; 

        

            if (i > 3)
            {
                i = 1;
            }

            picHolder.Source = new BitmapImage(new Uri(@"pics/" + i + ".PNG", UriKind.Relative));
            
        }

        //private void opensampuanwindow(object sender, RoutedEventArgs e)
        //{
        //    Sampuan sampuan = new Sampuan();
        //    this.Visibility = Visibility.Hidden;
        //    sampuan.Show();

        //}

        private void opensearchbox(object sender, RoutedEventArgs e)
        {
            

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

        private int currentElement = 0;

        //private void Left_Click(object sender, RoutedEventArgs e)
        //{
        //    if (currentElement < 2)
        //    {
        //        currentElement++;
        //        AnimateCarousel();
        //    }
        //}

        //private void Right_Click(object sender, RoutedEventArgs e)
        //{
        //    if (currentElement > 0)
        //    {
        //        currentElement--;
        //        AnimateCarousel();
        //    }
        //}

        //private void AnimateCarousel()
        //{
        //    Storyboard storyboard = (this.Resources["CarouselStoryboard"] as Storyboard);
        //    DoubleAnimation animation = storyboard.Children.First() as DoubleAnimation;
        //    animation.To = -this.Width * currentElement;
        //    storyboard.Begin();
        //}
    }
}
    

