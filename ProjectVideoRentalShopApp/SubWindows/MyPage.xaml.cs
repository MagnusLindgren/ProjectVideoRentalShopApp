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

            //State.User = API.GetCustomerByName("torand");
            //var currentUser = State.User;
        }
    }
}
