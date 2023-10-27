using SuperSimpleTcp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataReceivedEventArgs = SuperSimpleTcp.DataReceivedEventArgs;


// Beim senden der Nachricht auch den Empfänger mitsenden an den es geht
// Dann kann Server die Nachricht an den Empfänger genau so weiterleiten wie der es im video mit der client ip liste amcht mit "User" gleich dem der es geschickt hat
// 

namespace TCP
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        SimpleTcpServer server;

        private string [,] userIP = new string[1, 2];

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnSend.IsEnabled = false;
            server = new SimpleTcpServer(txtIP.Text);
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;
            // lstClientIP.Items.Add("192.168.178.46:7891");
        }

        private void Events_ClientConnected(object sender, ConnectionEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                txtInfo.Text += $"Server connected.{Environment.NewLine}";
                Console.WriteLine($"[{e.IpPort}] client connected");
                lstClientIP.Items.Add(e.IpPort);
                Console.WriteLine(e);
            });
        }

        private void Events_ClientDisconnected(object sender, ConnectionEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                lstClientIP.Items.Remove(e.IpPort);
            });
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            byte[] bytes = new byte[e.Data.Count];
            Array.Copy(e.Data.Array, e.Data.Offset, bytes, 0, e.Data.Count);

            Dispatcher.Invoke(() =>
            {
                txtInfo.Text += $"Server: {Encoding.UTF8.GetString(e.Data.Array, e.Data.Offset, e.Data.Count)}{Environment.NewLine}";
            });
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            // Add a handler to the Loaded event
            AddHandler(FrameworkElement.LoadedEvent, new RoutedEventHandler(Window_Loaded));
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            server.Start();
            txtInfo.Text += $"Startung...{Environment.NewLine}";
            btnStart.IsEnabled = false;
            btnSend.IsEnabled = true;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (server.IsListening)
            {
                if (!string.IsNullOrEmpty(txtMessage.Text) && lstClientIP.SelectedItems != null)
                {
                    server.Send(lstClientIP.SelectedItems[0].ToString(), txtMessage.Text);
                    txtInfo.Text += $"Server: {txtMessage.Text}{Environment.NewLine}";
                    txtMessage.Text = string.Empty;
                }
            }
        }

        private string FindIPAddressByName(string name)
        {
            for (int i = 0; i < userIP.GetLength(0); i++)
            {
                if (userIP[i, 0] == name)
                {
                    return userIP[i, 1];
                }
            }

            return null;
        }

        public void AddUserIP(string name, string ipAddress)
        {
            int rows = userIP.GetLength(0);
            int columns =userIP.GetLength(1);

            string[,] newArray = new string[rows + 1, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    newArray[i, j] = userIP[i, j];
                }
            }

            newArray[rows, 0] = name;
            newArray[rows, 1] = ipAddress;

            userIP = newArray;
        }
    }
}