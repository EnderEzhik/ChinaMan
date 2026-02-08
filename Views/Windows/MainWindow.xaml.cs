using System.Windows;
using System.Windows.Controls;
using ChinaMan.Database;
using ChinaMan.Database.Models;
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
        }
    }
}