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
        //nieuwe seriele poort aanmaken
        SerialPort serial = new SerialPort();
        //Connected variabele
        bool isConnected = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        //Leds inschakelen
        private void on_Click(object sender, RoutedEventArgs e)
        {
            //Als hij NIET geconnecteerd is
            if (!isConnected)
            {
                MessageBox.Show("Je moet eerst verbinden met de microcontroller.");
                return;
            }

            //kleurentextbox in een variabele steken
            string gekozenkleur = Kleurkeuzetextbox.Text;
            //kleurnummer komt overeen met de nummer dat overeen komt met de kleur (zie klasse "Kleurkeuze")
            string kleurnummer = Kleurkeuze.Kleurnaarnummer(gekozenkleur);
            //nummer doorsturen naar je serial
            serial.Write(kleurnummer);

            //bij nummer zeven error geven
            if (kleurnummer == "7")
            {
                MessageBox.Show("Ongeldig kleur");
            }
        }

        //Leds uitschakelen
        private void off_Click(object sender, RoutedEventArgs e)
        {
            //Als hij NIET geconnecteerd is
            if (!isConnected)
            {
                MessageBox.Show("Je moet eerst verbinden met de microcontroller.");
                return;
            }
            //alles uitschakelen
            serial.Write("0");
        }

        //COM poort connecteren
        private void connect_Click(object sender, RoutedEventArgs e)
        {
            //
            try
            {
                //poortnaam uit tekstbox halen
                serial.PortName = comportnumber.Text;
                //Communicatie snelheid instellen
                serial.BaudRate = 9600;
                //seriele poort openen
                serial.Open();
                isConnected = true;
                status.Text = "Connected";
            }
            catch (Exception)
            {
                //uitzondering (bij een foute poortnummer)
                MessageBox.Show("Geef een juiste COM poort nummer");
            }
        }

        //COM poort disconnecten
        private void disconnect_Click(object sender, RoutedEventArgs e)
        {
            //enkel als hij dus eerst geconnecteerd is
            if (isConnected)
            {
                try
                {
                    //seriele poort sluiten
                    serial.Close();
                    isConnected = false;
                    status.Text = "Disconnected";
                }
                catch (Exception)
                {
                    //als je eerst geconnecteerd hebt en wilt disconnecten maar het niet lukt
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