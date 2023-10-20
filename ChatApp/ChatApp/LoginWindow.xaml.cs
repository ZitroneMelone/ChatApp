using Microsoft.Extensions.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using Npgsql;
using System;

namespace ChatApp
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        ConfigurationBuilder cBuilder = new ConfigurationBuilder();
        NpgsqlConnection connection;
        public string connectionString;
        public LoginWindow()
        {
            InitializeComponent();

            

        }

        //get connection string from jsconfig.json file
        public static string Get()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("jsconfig.json")
                .Build();

            var connectionString = config.GetConnectionString("postgresql");
            var uri = new Uri(connectionString);
            var db = uri.AbsolutePath.Trim('/');
            var user = uri.UserInfo.Split(':')[0];
            var passwd = uri.UserInfo.Split(':')[1];
            var port = uri.Port > 0 ? uri.Port : 5432;
            var connStr = string.Format("Server={0};Database={1};User Id={2};Password={3};Port={4}",
                uri.Host, db, user, passwd, port);
            return connStr;
        }


        //connecting to the database when clicking a button
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            connectionString = Get();
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
