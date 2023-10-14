using ChatApp.Elements;
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


namespace ChatApp
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent(); 
        }

        private void OnSendMessageClick(object sender, RoutedEventArgs e)
        {
            // Get the message from the TextBox
            string message = MessageTextBox.Text;

            // Check if the message is not empty
            if (!string.IsNullOrWhiteSpace(message))
            {
                // Create a new ChatMessage object
                ChatMessage chatMessage = new ChatMessage(
                     "User", // Whatever the logged in Users Name is
                     message
                );

                // Add the message to the chat ListView (Doesn´t work yet, need to look into Bindings and DataContext first)
                ChatListView.Items.Add(chatMessage);

                // Clear the message input TextBox
                MessageTextBox.Clear();
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
    }
}
