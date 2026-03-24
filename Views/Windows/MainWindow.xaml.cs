using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using ChinaMan.ViewModels;
using ChinaMan.ViewModels.Base;
using ChinaMan.ViewModels.Items;

namespace ChinaMan
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (MainViewModel)this.DataContext;
            var tabItemContext = viewModel.CurrentTabItem.DataContext;
            var tabItemViewModel = (MovieListBaseViewModel)tabItemContext;
            var window = (Window)Activator.CreateInstance(tabItemViewModel.WindowType, tabItemContext)!;
            window.Show();
        }

        private void LoadViewedMovies(object sender, EventArgs e)
        {
            using var dbContext = App.CreateDbContext();

            var viewModel = (ViewedMoviesViewModel)((ListView)sender).DataContext;

            dbContext.ViewedMovies.Include(v => v.Film)
                .GroupBy(v => v.Film.Title)
                .Select(g => new ViewedMovieViewModel()
                {
                    Title = g.Key,
                    LastWatchedDate = g.Max(v => v.ViewedDate),
                    AvgRating = (float)g.Average(v => v.Rating),
                    ViewsCount = g.Count()
                }).ToList().ForEach(viewModel.ViewedMoviesList.Add);
        }

        private void LoadWatchingMovies(object sender, EventArgs e)
        {
            using var dbContext = App.CreateDbContext();

            var viewModel = (WatchingMoviesViewModel)((ListView)sender).DataContext;

            dbContext.WatchingMovies.Include(x => x.Film)
                .Select(x => x.Film.Title).ToList().ForEach(viewModel.WatchingMovies.Add);
        }

        private void LoadWantToViewMovies(object sender, EventArgs e)
        {
            using var dbContext = App.CreateDbContext();

            var viewModel = (WantToViewMovieViewModel)((ListView)sender).DataContext;

            dbContext.WantToViewMovies.Include(x => x.Film)
                .Select(x => x.Film.Title).ToList().ForEach(viewModel.WantToViewMovies.Add);
        }

        private void LoadAbandonedMovies(object sender, EventArgs e)
        {
            using var dbContext = App.CreateDbContext();

            var viewModel = (AbandonedMoviesViewModel)((ListView)sender).DataContext;

            dbContext.AbandonedMovies.Include(x => x.Film)
                .Select(x => new AbandonedMovieViewModel()
                {
                    Title = x.Film.Title,
                    AbandonReason = x.AbandonReason
                }).ToList().ForEach(viewModel.AbandonedMovies.Add);
        }
    }

    class TestConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var x = (float)value;
            if (x % 1 == 0)
            {
                return ((int)x).ToString();
            }
            else
            {
                return Math.Round(x, 1).ToString(CultureInfo.InvariantCulture);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}