using System.Windows;
using System.Windows.Controls;
using ChinaMan.Database;
using ChinaMan.Models;
using ChinaMan.ViewModels;

namespace ChinaMan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ApplicationContext dbContext;
        public MainWindow()
        {
            InitializeComponent();
            App.InitDatabase();
            dbContext = App.CreateDbContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddViewedMovieWindow().Show();
        }

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            var viewModel = (MainViewModel)this.DataContext;
            var movies = dbContext.viewedMovies.ToList();

            foreach (var movie in movies)
            {
                viewModel.ViewedMovies.Add(movie);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var btnContext = (ViewedMovie)((Button)sender).DataContext;
            var viewModel = (MainViewModel)this.DataContext;
            viewModel.ViewedMovies.Remove(btnContext);
            dbContext.viewedMovies.Remove(btnContext);
            dbContext.SaveChanges();
        }
    }
}