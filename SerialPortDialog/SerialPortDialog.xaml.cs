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
using System.Windows.Shapes;
using System.IO.Ports;

namespace SerialPortDialog
{
    /// <summary>
    /// Interaction logic for SerialPortDialog.xaml
    /// </summary>
    public partial class SerialPortDialog : Window
    {
        public string PortName { get; set; }
        public Parity Parity { get; set; } = Parity.None;
        public StopBits StopBits { get; set; } = StopBits.One;
        public Handshake Handshake { get; set; } = Handshake.None;
        public int BaudRate { get; set; } = 9600;
        public int DataBits { get; set; } = 8;

        public SerialPortDialog()
        {
            InitializeComponent();
            DataContext = this;
            foreach (var portName in SerialPort.GetPortNames())
            {
                if (PortName == "") PortName = portName;
                cbPorts.Items.Add(portName);
            }
        }
        public void GetSerialPortSettings(SerialPort port)
        {
            PortName = port.PortName;
            BaudRate = port.BaudRate;
            Parity = port.Parity;
            DataBits = port.DataBits;
            StopBits = port.StopBits;
            Handshake = port.Handshake;
        }
        public void SetSerialPort(SerialPort port)
        {
            port.PortName = PortName;
            port.BaudRate = BaudRate;
            port.Parity = Parity;
            port.DataBits = DataBits;
            port.StopBits = StopBits;
            port.Handshake = Handshake;
        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
