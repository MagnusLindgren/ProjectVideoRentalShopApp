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

            var nyheter = new Label()
            {
                Content = "Nyinkommet",
                Foreground = Brushes.White,
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            MovieGrid.Children.Add(nyheter);
            Grid.SetRow(nyheter, 0);
            Grid.SetColumn(nyheter, 0);

            var senaste = new Label()
            {
                Content = "Se igen",
                Foreground = Brushes.White,
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            MovieGrid.Children.Add(senaste);
            Grid.SetRow(senaste, 2);
            Grid.SetColumn(senaste, 0);

            for (int x = 0; x < MovieGrid.ColumnDefinitions.Count; x++)
            {
                State.Movies = API.GetMovieByNew();
                int i = 0 * MovieGrid.ColumnDefinitions.Count + x;
                if (i < State.Movies.Count)
                {
                    var movie = State.Movies[i];

                    var image = new Image()
                    {
                        Cursor = Cursors.Hand,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Margin = new Thickness(4, 4, 4, 4)
                    };
                    image.MouseUp += Image_MouseUp;

                    var title = new Label()
                    {
                        Content = movie.Title,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        FontSize = 10,
                        Foreground = Brushes.White,
                        Background = Brushes.Black
                    };

                    MovieGrid.Children.Add(image);
                    Grid.SetRow(image, 1);
                    Grid.SetColumn(image, x);
                    MovieGrid.Children.Add(title);
                    Grid.SetRow(title, 1);
                    Grid.SetColumn(title, x);

                    try
                    {
                        image.Source = new BitmapImage(new Uri(movie.ImageUrl));
                    }
                    catch (Exception e) when
                        (e is ArgumentNullException ||
                         e is System.IO.FileNotFoundException ||
                         e is UriFormatException)
                    {
                        image.Source = new BitmapImage(new Uri("https://wolper.com.au/wp-content/uploads/2017/10/image-placeholder.jpg"));
                    }
                }

            }

            for (int x = 0; x < MovieGrid.ColumnDefinitions.Count; x++)
            {
                State.User = API.GetCustomerByName("torand");
                int i = 0 * MovieGrid.ColumnDefinitions.Count + x;
                if (State.User.Rentals == null)
                {
                    var nothingRented = new Label //TODO Den syns inte?!
                    {
                        Content = "Du har inte tittat på något ännu",
                        FontSize = 20,
                        Foreground = Brushes.White
                    };
                    MovieGrid.Children.Add(nothingRented);
                    Grid.SetRow(nothingRented, 3);
                    Grid.SetColumn(nothingRented, 0);
                }

                else if (i < State.User.Rentals.Count)
                {
                    var rented = State.User.Rentals[i];

                    var image = new Image()
                    {
                        Cursor = Cursors.Hand,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Margin = new Thickness(4, 4, 4, 4)
                    };
                    image.MouseUp += Image_MouseUp;

                    var title = new Label()
                    {
                        Content = rented.Movies.Title,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        FontSize = 10,
                        Foreground = Brushes.White,
                        Background = Brushes.Black
                    };

                    MovieGrid.Children.Add(image);
                    Grid.SetRow(image, 3);
                    Grid.SetColumn(image, x);
                    MovieGrid.Children.Add(title);
                    Grid.SetRow(title, 3);
                    Grid.SetColumn(title, x);

                    try
                    {
                        image.Source = new BitmapImage(new Uri(rented.Movies.ImageUrl));
                    }
                    catch (Exception e) when
                        (e is ArgumentNullException ||
                         e is System.IO.FileNotFoundException ||
                         e is UriFormatException)
                    {
                        image.Source = new BitmapImage(new Uri("https://wolper.com.au/wp-content/uploads/2017/10/image-placeholder.jpg"));
                    }
                }

            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var x = Grid.GetColumn(sender as UIElement);
            var y = Grid.GetRow(sender as UIElement);

            int i = y * MovieGrid.ColumnDefinitions.Count + x;

            State.Pick = State.Movies[i];

            MessageBoxResult input = MessageBox.Show("Vill du se den här filmen?", "Uthyrning", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            switch (input)
            {
                case MessageBoxResult.Yes:
                    if (API.RegisterSale(State.User, State.Pick))
                        MessageBox.Show("Uthyrningen lyckades", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    else
                        MessageBox.Show("Något gick fel!", "Åh nej!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
