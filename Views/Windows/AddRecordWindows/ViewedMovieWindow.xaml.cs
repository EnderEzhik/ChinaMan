using System.Windows;
using ChinaMan.Database;
using ChinaMan.Database.Models;
using ChinaMan.ViewModels;
using ChinaMan.ViewModels.Items;

namespace ChinaMan
{
    /// <summary>
    /// Логика взаимодействия для AddViewedMovieWindow.xaml
    /// </summary>
    public partial class ViewedMovieWindow : Window
    {
        private readonly ViewedMoviesViewModel viewModel;

        public ViewedMovieWindow(object viewModel)
        {
            InitializeComponent();
            this.viewModel = (ViewedMoviesViewModel)viewModel;
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
            ApplicationContext dbContext = App.CreateDbContext();

            string filmTitle = this.FilmTitleInput.Text;

            Film film = GetOrCreateFilm(dbContext, filmTitle);

            var newView = new ViewedMovie()
            {
                Film = film,
                Rating = int.Parse(this.ViewRatingInput.Text)
            };
            dbContext.ViewedMovies.Add(newView);
            dbContext.SaveChanges();

            ViewedMovieViewModel? filmInfo = viewModel.ViewedMoviesList.FirstOrDefault(f => f.Title == filmTitle);
            if (filmInfo is null)
            {
                filmInfo = new ViewedMovieViewModel()
                {
                    Title = filmTitle,
                    AvgRating = newView.Rating,
                    LastWatchedDate = newView.ViewedDate,
                    ViewsCount = 1
                };

                viewModel.ViewedMoviesList.Add(filmInfo);
            }
            else
            {
                filmInfo.LastWatchedDate = newView.ViewedDate;
                var views = dbContext.ViewedMovies.Where(v => v.Film.Title == filmTitle);
                filmInfo.AvgRating = (float)views.Sum(v => v.Rating) / (float)views.Count();
                filmInfo.ViewsCount = views.Count();
            }
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
