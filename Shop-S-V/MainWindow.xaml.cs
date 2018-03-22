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

            List<Toode> Tooted = new List<Toode>();
            Tooted.Add(new Toode() { Nimi = "piim", Hind = 3, Kogus = 1 });

            ProductListBox.ItemsSource = Tooted;
        }
        public class Toode
        {
            public string Nimi { get; set; }
            public int Hind { get; set; }
            public int Kogus { get; set; }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
