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
using System.Collections.ObjectModel;

namespace Shop_S_V
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool LõpetaButtonClicked = false;
        public bool LisaVeelButtonClicked = false;

        public MainWindow()
        {
            InitializeComponent();
            Restarta();
        }
        ObservableCollection<Toode> ToodeteList = new ObservableCollection<Toode>();

        public void LõpetaButton_Click(object sender, RoutedEventArgs e)
        {
            LõpetaButtonClicked = true;
            //Button_Click_Kassa(object sender, RoutedEventArgs e);     //leia kuidas otse saada kassasse
            Restarta();
        }

        public void LisaVeelButton_Click(object sender, RoutedEventArgs e)
        {
            LisaVeelButtonClicked=true;
            Restarta();//leia nupp mis läheb otse "lisa uute"  
            Lisa.Visibility = Visibility.Visible;
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
            bool mane = true;
            while (mane == true)
            {
                if (ToodeteList.Any(Toode => Toode.Nimi == textbox1.Text))
                {
                    MessageBox.Show("See toode on juba olemas", "Message", MessageBoxButton.OK);
                    break;
                }
                else
                {
                    double textbox2Parsed = double.Parse(textbox2.Text);
                    int textbox3Parsed = int.Parse(textbox3.Text);
                    ToodeteList.Add(new Toode { Nimi = textbox1.Text, Hind = textbox2Parsed, Kogus=textbox3Parsed });
                    ToodeListBox.ItemsSource = ToodeteList;
                    MessageBox.Show("Uus toode edukalt lisatud", "Message", MessageBoxButton.OK);
                    textbox1.Visibility = Visibility.Hidden;
                    textbox2.Visibility = Visibility.Hidden;
                    textbox3.Visibility = Visibility.Hidden;
                    Toode.Visibility = Visibility.Hidden;
                    Hind.Visibility = Visibility.Hidden;
                    Kogus.Visibility = Visibility.Hidden;
                    Lisa_Toode.Visibility = Visibility.Hidden;
                    textbox1.Text = "";
                    textbox2.Text = "";
                    textbox3.Text = "";
                    LisaVõiLõpeta.Visibility = Visibility.Visible;
                    LisaVeelButton.Visibility = Visibility.Visible;
                    LõpetaButton.Visibility = Visibility.Visible;
                    Button_Summa.Visibility = Visibility.Hidden;
                    if (LõpetaButtonClicked == true)
                    {
                        LõpetaButtonClicked = true;
                        Restarta();
                    }
                    if (LisaVeelButtonClicked == true)
                    {
                        LisaVeelButtonClicked = false;
                        Lisa.Visibility = Visibility.Visible;
                        Restarta();//LisaVeelJuurde();
                    }
                    break;
                }
            }
        }

        public void Restarta()
        {
            textbox1.Visibility = Visibility.Hidden;
            textbox2.Visibility = Visibility.Hidden;
            textbox3.Visibility = Visibility.Hidden;
            Toode.Visibility = Visibility.Hidden;
            Hind.Visibility = Visibility.Hidden;
            Kogus.Visibility = Visibility.Hidden;
            Kassa.Visibility = Visibility.Visible;
            Lisa_Toode.Visibility = Visibility.Hidden;
            LisaVõiLõpeta.Visibility = Visibility.Hidden;
            LisaVeelButton.Visibility = Visibility.Hidden;
            LõpetaButton.Visibility = Visibility.Hidden;
            Label_Ostukorv.Visibility = Visibility.Hidden;
            Label_Toode.Visibility = Visibility.Hidden;
            Label_Hind.Visibility = Visibility.Hidden;
            Label_Kogus.Visibility = Visibility.Hidden;
            ToodeListBox.Visibility = Visibility.Hidden;
            Button_Summa.Visibility = Visibility.Hidden;
        }

        public void LisaVeelJuurde()
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
            Button_Summa.Visibility = Visibility.Hidden;
        }

        private void Restart(object sender,RoutedEventArgs e)
        {
            textbox1.Visibility = Visibility.Hidden;
            textbox2.Visibility = Visibility.Hidden;
            textbox3.Visibility = Visibility.Hidden;
            Toode.Visibility = Visibility.Hidden;
            Hind.Visibility = Visibility.Hidden;
            Kogus.Visibility = Visibility.Hidden;
            Kassa.Visibility = Visibility.Visible;
            Lisa_Toode.Visibility = Visibility.Visible;
            Lisa.Visibility = Visibility.Visible;
            ToodeListBox.Visibility = Visibility.Hidden;
            Label_Ostukorv.Visibility = Visibility.Hidden;
            Label_Toode.Visibility = Visibility.Hidden;
            Label_Hind.Visibility = Visibility.Hidden;
            Label_Kogus.Visibility = Visibility.Hidden;
            Button_Summa.Visibility = Visibility.Hidden;
        }

        private void Button_Click_Kassa(object sender, RoutedEventArgs e)
        {
            Lisa_Toode.Visibility = Visibility.Hidden;
            Kassa.Visibility = Visibility.Hidden;
            Lisa.Visibility = Visibility.Hidden;
            Label_Ostukorv.Visibility = Visibility.Visible;
            ToodeListBox.Visibility = Visibility.Visible;
            Label_Toode.Visibility = Visibility.Visible;
            Label_Hind.Visibility = Visibility.Visible;
            Label_Kogus.Visibility = Visibility.Visible;
            Button_Summa.Visibility = Visibility.Visible;
        }

        private void Button_Summa_Click(object sender, RoutedEventArgs e)
        {
            double summa=0;
            foreach(var toode in ToodeteList)
            {
                summa += toode.Hind * toode.Kogus;
            }
            MessageBox.Show("Teie ostusumma on "+summa+"€","Summa",MessageBoxButton.OK);
        }
    }
}
