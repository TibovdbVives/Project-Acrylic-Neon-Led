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
            string kleurnummer = Kleurkeuze.Kleurnaarnummer(gekozenkleur);
            serial.Write(kleurnummer);

            if (kleurnummer == "7")
            {
                MessageBox.Show("Ongeldig kleur");
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
                if(status.Text == "Connected")
                {

                }
                else
                {
                    MessageBox.Show("Geef een juiste COM poort nummer");
                }
                
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
    }
}