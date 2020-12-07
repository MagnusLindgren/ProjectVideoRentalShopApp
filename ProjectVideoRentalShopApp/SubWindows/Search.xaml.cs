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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : UserControl
    {
        public Search()
        {
            InitializeComponent();
            
            for (int y = 0; y < MovieGrid.RowDefinitions.Count; y++)
            {
                for (int x = 0; x < MovieGrid.ColumnDefinitions.Count; x++)
                {
                    int i = y * MovieGrid.ColumnDefinitions.Count + x;
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
                        Grid.SetRow(image, y);
                        Grid.SetColumn(image, x);
                        MovieGrid.Children.Add(title);
                        Grid.SetRow(title, y);
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
            }
            KeyDown += new KeyEventHandler(MovieSearchKeyDown);
        }

        public void MovieSearchKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                State.Movies.Clear();
                State.Movies.AddRange(API.GetMovieByTitle(Searchbox.Text));
                State.Movies.AddRange(API.GetMovieByCategory(Searchbox.Text));
                //UserControl Search = new UserControl();
                //Application.Current.Dispatcher.Invoke();
            }
        }

        private void textbox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Searchbox.Clear();
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
