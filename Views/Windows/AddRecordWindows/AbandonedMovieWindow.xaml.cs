using ChinaMan.Database;
using ChinaMan.Database.Models;
using ChinaMan.ViewModels;
using ChinaMan.ViewModels.Items;
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
    /// Логика взаимодействия для AbandonedMovieWindow.xaml
    /// </summary>
    public partial class AbandonedMovieWindow : Window
    {
        private readonly AbandonedMoviesViewModel viewModel;
        public AbandonedMovieWindow(object viewModel)
        {
            InitializeComponent();
            this.viewModel = (AbandonedMoviesViewModel)viewModel;
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
            string abandonedReason = this.AbandonedReasonInput.Text;

            Film film = GetOrCreateFilm(dbContext, filmTitle);

            var newAbandonedMovie = new AbandonedMovie()
            {
                Film = film,
                AbandonReason = abandonedReason
            };

            dbContext.AbandonedMovies.Add(newAbandonedMovie);
            dbContext.SaveChanges();

            var filmInfo = new AbandonedMovieViewModel()
            {
                Title = filmTitle,
                AbandonReason = abandonedReason
            };

            viewModel.AbandonedMovies.Add(filmInfo);
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
