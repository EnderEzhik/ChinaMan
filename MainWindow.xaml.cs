using System.Windows;
using ChinaMan.ViewModels;

namespace ChinaMan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            App.InitDatabase();
            viewModel = new MainViewModel();
            this.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddViewedMovieWindow().Show();
        }

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            using var dbContext = App.CreateDbContext();
            var movies = dbContext.viewedMovies.ToList();

            foreach (var movie in movies)
            {
                viewModel.ViewedMovies.Add(movie);
            }
        }
    }
}