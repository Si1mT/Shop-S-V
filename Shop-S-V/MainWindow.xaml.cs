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
        ObservableCollection<Toode> OstukorviList = new ObservableCollection<Toode>();

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
            Toode.Visibility = Visibility.Visible;
            Hind.Visibility = Visibility.Visible;
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
                    ToodeteList.Add(new Toode { Nimi = textbox1.Text, Hind = textbox2Parsed,});
                    ToodeListBox.ItemsSource = ToodeteList;
                    MessageBox.Show("Uus toode edukalt lisatud", "Message", MessageBoxButton.OK);
                    textbox1.Visibility = Visibility.Hidden;
                    textbox2.Visibility = Visibility.Hidden;
                    Toode.Visibility = Visibility.Hidden;
                    Hind.Visibility = Visibility.Hidden;
                    Lisa_Toode.Visibility = Visibility.Hidden;
                    textbox1.Text = "";
                    textbox2.Text = "";
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
            Toode.Visibility = Visibility.Hidden;
            Hind.Visibility = Visibility.Hidden;
            Kassa.Visibility = Visibility.Visible;
            Lisa_Toode.Visibility = Visibility.Hidden;
            LisaVõiLõpeta.Visibility = Visibility.Hidden;
            LisaVeelButton.Visibility = Visibility.Hidden;
            LõpetaButton.Visibility = Visibility.Hidden;
            Label_Ostukorv.Visibility = Visibility.Hidden;
            Label_Toode.Visibility = Visibility.Hidden;
            Label_Hind.Visibility = Visibility.Hidden;
            LabelOstukorvKogus.Visibility = Visibility.Hidden;
            ToodeListBox.Visibility = Visibility.Hidden;
            Button_Summa.Visibility = Visibility.Hidden;
            LisageOstukorvi.Visibility = Visibility.Hidden;
            OstukorvListBox.Visibility = Visibility.Hidden;
            Tooted.Visibility = Visibility.Hidden;
            Lisa.Visibility = Visibility.Visible;
            LabelOstukorvHind.Visibility = Visibility.Hidden;
            LabelOstukorvToode.Visibility = Visibility.Hidden;
            TextBoxKogus.Visibility = Visibility.Hidden;
            ButtonEemalda.Visibility = Visibility.Hidden;
        }

        public void LisaVeelJuurde()
        {
            textbox1.Visibility = Visibility.Visible;
            textbox2.Visibility = Visibility.Visible;
            Toode.Visibility = Visibility.Visible;
            Hind.Visibility = Visibility.Visible;
            Lisa.Visibility = Visibility.Hidden;
            Kassa.Visibility = Visibility.Hidden;
            Lisa_Toode.Visibility = Visibility.Visible;
            Button_Summa.Visibility = Visibility.Hidden;
        }

        private void Restart(object sender,RoutedEventArgs e)
        {
            textbox1.Visibility = Visibility.Hidden;
            textbox2.Visibility = Visibility.Hidden;
            Toode.Visibility = Visibility.Hidden;
            Hind.Visibility = Visibility.Hidden;
            Kassa.Visibility = Visibility.Visible;
            Lisa_Toode.Visibility = Visibility.Visible;
            Lisa.Visibility = Visibility.Visible;
            ToodeListBox.Visibility = Visibility.Hidden;
            Label_Ostukorv.Visibility = Visibility.Hidden;
            Label_Toode.Visibility = Visibility.Hidden;
            Label_Hind.Visibility = Visibility.Hidden;
            LabelOstukorvKogus.Visibility = Visibility.Hidden;
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
            LabelOstukorvKogus.Visibility = Visibility.Visible;
            Button_Summa.Visibility = Visibility.Visible;
            LisageOstukorvi.Visibility = Visibility.Visible;
            OstukorvListBox.Visibility = Visibility.Visible;
            Tooted.Visibility = Visibility.Visible;
            LabelOstukorvHind.Visibility = Visibility.Visible;
            LabelOstukorvToode.Visibility = Visibility.Visible;
            TextBoxKogus.Visibility = Visibility.Visible;
            ButtonEemalda.Visibility = Visibility.Visible;
        }

        private void Button_Summa_Click(object sender, RoutedEventArgs e)
        {
            double summa = 0;
                foreach (var item in OstukorviList)
                {
                    summa += item.Hind * item.Kogus;
                }
            MessageBox.Show("Teie ostusumma on " + summa + "€", "Summa", MessageBoxButton.OK);
        }

        private void Button_LisaOstukorvi_Click(object sender, RoutedEventArgs e)
        {
            if (ToodeListBox.SelectedIndex > -1)
            {
                var valik = OstukorviList.Where(x => String.Equals(x.Nimi, ToodeteList[ToodeListBox.SelectedIndex].Nimi));
                if (valik.Any())
                {
                    foreach (var item in valik)
                    {
                        item.Kogus += int.Parse(TextBoxKogus.Text);
                    }
                }
                else
                {
                    OstukorviList.Add(ToodeteList[ToodeListBox.SelectedIndex]);
                    OstukorviList[OstukorviList.Count - 1].Kogus = int.Parse(TextBoxKogus.Text);
                }
            }
            OstukorvListBox.ItemsSource = null;
            OstukorvListBox.ItemsSource = OstukorviList;
        }

        private void Button_Eemalda_Click(object sender, RoutedEventArgs e)
        {
            int index = OstukorvListBox.SelectedIndex;
            OstukorviList.RemoveAt(index);
        }
    }
}
