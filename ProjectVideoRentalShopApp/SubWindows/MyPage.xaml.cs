﻿using System;
using System.Collections.Generic;
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
using DataBaseConnection;

namespace ProjectVideoRentalShopApp.SubWindows
{
    /// <summary>
    /// Interaction logic for MyPage.xaml
    /// </summary>
    public partial class MyPage : UserControl
    {
        public MyPage()
        {
            InitializeComponent();

            //State.User = API.GetCustomerByName("torand"); //hämtar direkt från databasen (ta bort när inloggning fungerar)
            var currentUser = State.User; // hämtar från state.cs (den här från inloggningen)            

            Username.Content = currentUser.Username;
            Name.Content = currentUser.FirstName + " " + currentUser.LastName;
            Address.Content = currentUser.Address;
            Phone.Content = currentUser.Phone;
        }


        private void AddressChange_Click(object sender, RoutedEventArgs e)
        {
            var change = new TextBox()
            {
                Height = 30,
                VerticalAlignment = VerticalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center
            };

            UserInfo.Children.Add(change);
            Grid.SetRow(change, 2);
            Grid.SetColumn(change, 1);
            MessageBox.Show("Not implemented yet", "Please contact Admin for more help", MessageBoxButton.OK);
        }

        private void PhoneChange_Click(object sender, RoutedEventArgs e)
        {
            var change = new TextBox()
            {
                Height = 30,
                VerticalAlignment = VerticalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center
            };

            UserInfo.Children.Add(change);
            Grid.SetRow(change, 3);
            Grid.SetColumn(change, 1);
            MessageBox.Show("Not implemented yet", "Please contact Admin for more help", MessageBoxButton.OK);
        }
    }
}
