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
using System.IO;

namespace Shop_S_V
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            textbox1.Visibility = Visibility.Hidden;
            textbox2.Visibility = Visibility.Hidden;
            textbox3.Visibility = Visibility.Hidden;
            Toode.Visibility = Visibility.Hidden;
            Hind.Visibility = Visibility.Hidden;
            Kogus.Visibility = Visibility.Hidden;
            Kassa.Visibility = Visibility.Visible;
            Lisa_Toode.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textbox1.Visibility = Visibility.Visible;
            textbox2.Visibility = Visibility.Visible;
            textbox3.Visibility = Visibility.Visible;
            Toode.Visibility = Visibility.Visible;
            Hind.Visibility = Visibility.Visible;
            Kogus.Visibility = Visibility.Visible;
            Lisa.Visibility = Visibility.Hidden;
            Kassa.Visibility = Visibility.Hidden;
            Lisa_Toode.Visibility = Visibility.Visible;

        }

        private void Button_Click_LisaToode(object sender, RoutedEventArgs e)
        {
            if (File.Exists("../../toode/" + textbox1.Text + ".txt"))
            {
                MessageBox.Show("See toode on juba olemas", "Message", MessageBoxButton.OK);
            }
            else
            {
                File.WriteAllText("../../toode/" + textbox1.Text + ".txt", textbox2.Text + "\n" + textbox3.Text);
                MessageBox.Show("Uus toode edukalt lisatud", "Message", MessageBoxButton.OK);
            }
                
        }

        private void Restart(object sender, RoutedEventArgs e)
        {
            textbox1.Visibility = Visibility.Hidden;
            textbox2.Visibility = Visibility.Hidden;
            textbox3.Visibility = Visibility.Hidden;
            Toode.Visibility = Visibility.Hidden;
            Hind.Visibility = Visibility.Hidden;
            Kogus.Visibility = Visibility.Hidden;
            Kassa.Visibility = Visibility.Visible;
            Lisa_Toode.Visibility = Visibility.Hidden;
            Lisa.Visibility = Visibility.Visible;
        }

        private void Button_Click_Kassa(object sender, RoutedEventArgs e)
        {
            Lisa_Toode.Visibility = Visibility.Hidden;
            Kassa.Visibility = Visibility.Hidden;
            Lisa.Visibility = Visibility.Hidden;
        }
    }
}
