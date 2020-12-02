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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            /*
            for (int i = 0; i < MovieGrid.RowDefinitions.Count; i++)
            {
                for (int y = 0; y < MovieGrid.ColumnDefinitions.Count; y++)
                {
                    int x = i * MovieGrid.ColumnDefinitions.Count + y;
                    if (x < State.Movies.Count)
                    {
                        var movie = State.Movies[i];

                        try
                        {
                            var image = new Image();
                            image.Source = new BitmapImage(new Uri(movie.ImageUrl));

                            var title = new Label();
                            title.Content = movie.Title;
                        }
                        catch (Exception e) when
                            (e is ArgumentNullException ||
                             e is System.IO.FileNotFoundException ||
                             e is UriFormatException)
                        {
                            continue;
                        }
                    }
                }
            }*/
        }
        
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var x = Grid.GetColumn(sender as UIElement);
            var y = Grid.GetRow(sender as UIElement);

            int i = y * MovieGrid.ColumnDefinitions.Count + x;

            State.Pick = State.Movies[i];

            if (API.RegisterSale(State.User, State.Pick))
                MessageBox.Show("All is well and you can download your movie now.", "Sale Succeeded!", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("An error happened while buying the movie, please try again at a later time.", "Sale Failed!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }
}
