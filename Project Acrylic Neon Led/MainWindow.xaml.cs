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
    }
}