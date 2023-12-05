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
        SerialPort sp = new SerialPort();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void on_Click(object sender, RoutedEventArgs e)
        {
            //testen
            sp.Write("0002");
            sp.Write("1");
        }

        private void off_Click(object sender, RoutedEventArgs e)
        {
            sp.Write("0");
        }

        private void connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String portName = comportnumber.Text;
                sp.PortName = portName;
                sp.BaudRate = 9600;
                sp.Open();
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
                sp.Close();
                status.Text = "Disconnected";
            }
            catch (Exception)
            {
                MessageBox.Show("First connect and then disconnect");
            }
        }
    }
}