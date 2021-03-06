﻿using System;
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
using DataBaseConnection;
using ProjectVideoRentalShopApp.SubWindows;

namespace ProjectVideoRentalShopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
            Title.Content = "Nyheter";
            Home.Visibility = Visibility.Visible;
            MyPage.Visibility = Visibility.Hidden;
            VideoStore.Visibility = Visibility.Hidden;
            Search.Visibility = Visibility.Hidden;
        }

        private void GoMyPage_Click(object sender, RoutedEventArgs e)
        {
            Title.Content = "Profil";
            Home.Visibility = Visibility.Hidden;
            MyPage.Visibility = Visibility.Visible;
            VideoStore.Visibility = Visibility.Hidden;
            Search.Visibility = Visibility.Hidden;           
        }

        private void GoStore_Click(object sender, RoutedEventArgs e)
        {
            Title.Content = "Butik";
            Home.Visibility = Visibility.Hidden;
            MyPage.Visibility = Visibility.Hidden;
            VideoStore.Visibility = Visibility.Visible;
            Search.Visibility = Visibility.Hidden;
        }

        private void GoSearch_Click(object sender, RoutedEventArgs e)
        {
            Title.Content = "Sök";
            Home.Visibility = Visibility.Hidden;
            MyPage.Visibility = Visibility.Hidden;
            VideoStore.Visibility = Visibility.Hidden;
            Search.Visibility = Visibility.Hidden;
            // Tillfällig messagebox då jag inte får search att uppdatera sig
            MessageBox.Show("The page you are trying to reach are not implemented yet. Please try again later.", "Not implemented", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Title_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
