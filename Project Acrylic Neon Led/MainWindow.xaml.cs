using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;

namespace Project_Acrylic_Neon_Led
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort serial = new SerialPort();
        bool isConnected = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void on_Click(object sender, RoutedEventArgs e)
        {
            if (!isConnected)
            {
                MessageBox.Show("Je moet eerst verbinden met de microcontroller.");
                return;
            }

            string gekozenkleur = Kleurkeuzetextbox.Text;
            if (string.Equals(gekozenkleur, "Rood", StringComparison.OrdinalIgnoreCase))
            {
                serial.Write("1");
            }
            else if (string.Equals(gekozenkleur, "Blauw", StringComparison.OrdinalIgnoreCase))
            {
                serial.Write("2");
            }
            else if (string.Equals(gekozenkleur, "Groen", StringComparison.OrdinalIgnoreCase))
            {
                serial.Write("3");
            }
            else
            {
                MessageBox.Show("Geef een geldig kleur");
            }
        }

        private void off_Click(object sender, RoutedEventArgs e)
        {
            if (!isConnected)
            {
                MessageBox.Show("Je moet eerst verbinden met de microcontroller.");
                return;
            }
            serial.Write("0");
        }

        private void connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String portName = comportnumber.Text;
                serial.PortName = portName;
                serial.BaudRate = 9600;
                serial.Open();
                isConnected = true;
                status.Text = "Connected";
            }
            catch (Exception)
            {
                MessageBox.Show("Geef een juiste COM poort nummer");
            }
        }

        private void disconnect_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                try
                {
                    serial.Close();
                    isConnected = false;
                    status.Text = "Disconnected";
                }
                catch (Exception)
                {
                    MessageBox.Show("Er is een fout opgetreden bij het verbreken van de verbinding.");
                }
            }
            else
            {
                MessageBox.Show("Je bent momenteel niet verbonden.");
            }
        }

        private void kleurtest()
        {

        }



        /*
         * Eerst testen met gewoon een led aan doen op het board zelf
         * dan kijken voor verschillende kleuren zijn verschillende leds
         * vragen thuis hoelang 1 zo'n strip is van led en op hoeveel volt dat werkt dat ik de juiste hoeveelheid spanning stuur naar de leds
         * verschillende uitgangen kunnen aansturen/meten met multimeter
         * uiteindelijk aansturen
         */
    }
}