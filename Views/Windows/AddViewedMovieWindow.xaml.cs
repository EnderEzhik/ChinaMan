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
            string filmTitle = this.FilmTitleInput.Text;
            Film? film = dbContext.Films.FirstOrDefault(f => f.Title == filmTitle);
            if (film is null)
            {
                film = new Film()
                {
                    Title = filmTitle
                };
                dbContext.Films.Add(film);
            }

            View newView = new View()
            {
                Film = film,
                Rating = int.Parse(this.ViewRatingInput.Text)
            };
            dbContext.Views.Add(newView);

            dbContext.SaveChanges();

            FilmInfoViewModel? filmInfo = MainViewModel.Instance.FilmInfoList.FirstOrDefault(f => f.Title == filmTitle);
            if (filmInfo is null)
            {
                filmInfo = new FilmInfoViewModel()
                {
                    Title = filmTitle,
                    AvgRating = newView.Rating,
                    LastWatchedDate = newView.ViewedDate,
                    ViewsCount = 1
                };

                MainViewModel.Instance.FilmInfoList.Add(filmInfo);
            }
            else
            {
                filmInfo.LastWatchedDate = newView.ViewedDate;
                var views = dbContext.Views.Where(v => v.Film.Title == filmTitle);
                filmInfo.AvgRating = views.Sum(v => v.Rating) / views.Count();
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
