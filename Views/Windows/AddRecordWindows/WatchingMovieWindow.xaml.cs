using ChinaMan.Database;
using ChinaMan.Database.Models;
using ChinaMan.ViewModels;
using ChinaMan.ViewModels.Base;
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
using System.Windows.Shapes;

namespace ChinaMan.Views.Windows.AddRecordWindows
{
    /// <summary>
    /// Логика взаимодействия для WatchingMovieWindow.xaml
    /// </summary>
    public partial class WatchingMovieWindow : Window
    {
        private readonly WatchingMoviesViewModel viewModel;

        public WatchingMovieWindow(object viewModel)
        {
            InitializeComponent();
            this.viewModel = (WatchingMoviesViewModel)viewModel;
        }

        private Film GetOrCreateFilm(ApplicationContext dbContext, string filmTitle)
        {
            Film? film = dbContext.Films.FirstOrDefault(f => f.Title == filmTitle);
            if (film is null)
            {
                film = new Film()
                {
                    Title = filmTitle
                };
                dbContext.Films.Add(film);
            }
            return film;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using var dbContext = App.CreateDbContext();

            string filmTitle = this.FilmTitleInput.Text;

            Film film = GetOrCreateFilm(dbContext, filmTitle);

            var newWatchingMovie = new WatchingMovie()
            {
                Film = film
            };

            dbContext.WatchingMovies.Add(newWatchingMovie);
            dbContext.SaveChanges();

            viewModel.WatchingMovies.Add(filmTitle);
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
