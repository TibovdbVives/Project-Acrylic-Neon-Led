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
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void on_Click(object sender, RoutedEventArgs e)
        { 
            serial.Write("1");
        }

        private void off_Click(object sender, RoutedEventArgs e)
        {
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
                status.Text = "Connected";
            }
            catch (Exception)
            {
                MessageBox.Show("Give valid port number");
            }
        }

        private void disconnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                serial.Close();
                status.Text = "Disconnected";
            }
            catch (Exception)
            {
                MessageBox.Show("First connect and then disconnect");
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