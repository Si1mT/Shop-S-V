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
using System.Windows.Threading;
using System.Threading;

namespace Shop_S_V
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool LõpetaButtonClicked = false;
        public bool LisaVeelButtonClicked = false;
        public bool LisaVõiLõpetaClicked = false;

        public MainWindow()
        {
            InitializeComponent();
            Restarta();
        }
        public void LõpetaButton_Click(object sender, RoutedEventArgs e)
        {
            LõpetaButtonClicked = true;
            LisaVõiLõpetaClicked = true;

        }

        public void LisaVeelButton_Click(object sender, RoutedEventArgs e)
        {
            LisaVeelButtonClicked = true;
            LisaVõiLõpetaClicked = true;
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
                if (File.Exists("../../toode/" + textbox1.Text + ".txt"))
                {
                    MessageBox.Show("See toode on juba olemas", "Message", MessageBoxButton.OK);
                    break;
                }
                else
                {
                    File.WriteAllText("../../toode/" + textbox1.Text + ".txt", textbox2.Text + "\n" + textbox3.Text);
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
                    while (LisaVõiLõpetaClicked == false)
                    {
                        Application.Current.Dispatcher.Invoke(
                        DispatcherPriority.Background,
                         new ThreadStart(delegate { }));
                    }
                    if (LõpetaButtonClicked == true)
                    {
                        LõpetaButtonClicked = false;
                        Restarta();
                        break;
                    }
                    if (LisaVeelButtonClicked == true)
                    {
                        LisaVeelButtonClicked = false;
                        LisaVeelJuurde();
                        break;
                    }
                    break;
                }
            }
                
        }
        public void Restarta()
        {
            Lisa.Visibility = Visibility.Visible;
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
            textbox1.Text = "";
            textbox2.Text = "";
            textbox3.Text = "";
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

        }
        private void Restart(object sender, RoutedEventArgs e)
        {
            Restarta();
        }

        private void Button_Click_Kassa(object sender, RoutedEventArgs e)
        {
            Lisa_Toode.Visibility = Visibility.Hidden;
            Kassa.Visibility = Visibility.Hidden;
            Lisa.Visibility = Visibility.Hidden;
        }


    }
}
