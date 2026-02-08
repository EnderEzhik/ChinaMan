using System.Windows;
using ChinaMan.Database;
using ChinaMan.Database.Models;
using ChinaMan.ViewModels;

namespace ChinaMan
{
    /// <summary>
    /// Логика взаимодействия для AddViewedMovieWindow.xaml
    /// </summary>
    public partial class AddViewedMovieWindow : Window
    {
        private readonly ApplicationContext dbContext;

        public AddViewedMovieWindow()
        {
            InitializeComponent();
            dbContext = App.CreateDbContext();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Film newFilm = new Film()
            {
                Title = this.FilmTitleInput.Text
            };
            dbContext.Films.Add(newFilm);
            dbContext.SaveChanges();
            MainViewModel.Instance.Films.Add(newFilm);
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
