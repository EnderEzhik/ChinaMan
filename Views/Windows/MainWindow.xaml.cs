using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;
using ChinaMan.ViewModels;
using ChinaMan.ViewModels.Items;
using System.Windows.Controls;
using ChinaMan.ViewModels.Base;

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
            var tabItemViewModel = (MovieListBaseViewModel)viewModel.CurrentTabItem.DataContext;
            var window = (Window)Activator.CreateInstance(tabItemViewModel.WindowType)!;
            window.Show();
        }

        private void ListView_Initialized(object sender, EventArgs e)
        {
            var dbContext = App.CreateDbContext();

            var viewModel = (ViewedMoviesViewModel)((ListView)sender).DataContext;

            dbContext.Films.Include(f => f.Views).Select(f => new ViewedMovieViewModel()
            {
                Title = f.Title,
                LastWatchedDate = f.Views.OrderByDescending(v => v.ViewedDate).First().ViewedDate,
                AvgRating = (float)f.Views.Sum(v => v.Rating) / (float)f.Views.Count(),
                ViewsCount = f.Views.Count()
            }).ToList().ForEach(viewModel.ViewedMoviesList.Add);
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