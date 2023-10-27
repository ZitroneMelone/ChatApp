using ChatApp.Elements;
using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Extensions.Configuration;
using Npgsql;
using Microsoft.Extensions.Configuration.Json;
using System.Data;
using SuperSimpleTcp;
using System.Globalization;

namespace ChatApp
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();           
        }

        SimpleTcpClient client = new SimpleTcpClient("192.168.178.46:7891");

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            client.Events.Connected += Events_Connected;
            client.Events.DataReceived += Events_DataReceived;
            client.Events.Disconnected += Events_Disconnected;
            client.Connect();
        }

        private void Events_Connected(object sender, ConnectionEventArgs e)
        {

        }

        private void Events_Disconnected(object sender, ConnectionEventArgs e)
        {

        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            byte[] receivedData = new byte[e.Data.Count];
            Array.Copy(e.Data.Array, e.Data.Offset, receivedData, 0, e.Data.Count);

            string receivedMessage = Encoding.UTF8.GetString(receivedData);

            Console.WriteLine(receivedMessage);

            Dispatcher.Invoke(() =>
            {

                ChatMessage chatMessage = new ChatMessage(
                     "Server", // Whatever the logged in Users Name is
                     receivedMessage
                );
                ChatListView.Items.Add(chatMessage);
            });

        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            // Add a handler to the Loaded event
            AddHandler(FrameworkElement.LoadedEvent, new RoutedEventHandler(Window_Loaded));
        }

        public static void Connection()
        {
            
        }

        private void OnSendMessageClick(object sender, RoutedEventArgs e)
        {
            // Get the message from the TextBox
            string message = MessageTextBox.Text;

            if (client.IsConnected) {

                if (!string.IsNullOrWhiteSpace(message))
                {
                    // Create a new ChatMessage object
                    ChatMessage chatMessage = new ChatMessage(
                         "User", // Whatever the logged in Users Name is
                         message
                    );

                    // Add the message to the chat ListView (Doesn´t work yet, need to look into Bindings and DataContext first)
                    ChatListView.Items.Add(chatMessage);

                    client.Send(message);

                    // Clear the message input TextBox
                    MessageTextBox.Clear();

                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Panel.Width = 150;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Panel.Width = 0;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void ChatListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
