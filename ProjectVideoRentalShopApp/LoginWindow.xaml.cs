using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataBaseConnection;

namespace ProjectVideoRentalShopApp
{
    
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {

            string username_in_text = NameField.Text.Trim();

            State.User = API.GetCustomerByName(username_in_text);
 
            if (State.User != null)
            {
                var next_window = new MainWindow();
                next_window.Show();
                this.Close();
            }
            else
            {
                NameField.Text = "...";
            }
        }
    }
}

