using System.Windows;
using ChinaMan.Database;
using ChinaMan.Models;
using ChinaMan.ViewModels;

namespace ChinaMan
{
    /// <summary>
    /// Логика взаимодействия для AddViewedMovieWindow.xaml
    /// </summary>
    public partial class AddViewedMovieWindow : Window
    {
        public AddViewedMovieWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string title = this.MovieTitleInput.Text;
            string description = this.MovieDescriptionInput.Text;
            string rating = this.MovieRatingInput.Text;
            DateTime viewedDate = this.MovieViewedDate.SelectedDate.HasValue ? this.MovieViewedDate.SelectedDate.Value : DateTime.Now;
            viewedDate = viewedDate.Date;

            ViewedMovie movieData = new ViewedMovie();
            movieData.Title = title;
            movieData.Description = description;
            movieData.Rating = int.Parse(rating);
            movieData.ViewedDate = viewedDate;

            using (var dbContext = App.CreateDbContext())
            {
                DatabaseService.SaveViewedMovie(dbContext, movieData);
            }

            MainViewModel.Instance.ViewedMovies.Add(movieData);
            this.Close();
        }
    }
}
