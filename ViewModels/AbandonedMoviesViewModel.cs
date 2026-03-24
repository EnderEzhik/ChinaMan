using System.Collections.ObjectModel;
using ChinaMan.ViewModels.Base;
using ChinaMan.ViewModels.Items;
using ChinaMan.Views.Windows.AddRecordWindows;

namespace ChinaMan.ViewModels
{
    internal class AbandonedMoviesViewModel : MovieListBaseViewModel
    {
        private ObservableCollection<AbandonedMovieViewModel> _abandonedMovies;
        public ObservableCollection<AbandonedMovieViewModel> AbandonedMovies
        {
            get => _abandonedMovies;
            set => Set(ref _abandonedMovies, value);
        }

        public AbandonedMoviesViewModel() : base(typeof(AbandonedMovieWindow))
        {
            _abandonedMovies = new();
            AbandonedMovies = new();
        }
    }
}
