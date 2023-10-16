using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using Microsoft.Extensions.Configuration.Json;

namespace ChatApp
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        ConfigurationBuilder cBuilder = new ConfigurationBuilder();
        NpgsqlConnection connection ;
        public string connectionString;
        public LoginWindow()
        {
            InitializeComponent();

            

        }

        //get connection string from jsconfig.json file
        public void GetConnString(string ServerName)
        {
            cBuilder.SetBasePath(Directory.GetCurrentDirectory());
            cBuilder.AddJsonFile("jsconfig.json");

            var config = cBuilder.Build();

            connectionString = config.GetConnectionString(ServerName);
        }


        //connecting to the database when clicking a button
        private void Login_Click(object sender, RoutedEventArgs e)
        {

            GetConnString("postgresql");
            connection = new NpgsqlConnection(connectionString);
            connection.Open();

            //Checking connection status
            if (connection.State == ConnectionState.Open)
            {
                MessageBox.Show("Connection Open");

            }
            else
            {
                MessageBox.Show("Failed to open connection");
            }
        }
    


        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();   
            registrationWindow.Show();
            this.Close();

        }
    }
}
