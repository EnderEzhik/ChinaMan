using System.Collections.ObjectModel;
using ChinaMan.ViewModels.Base;
using ChinaMan.Views.Windows.AddRecordWindows;

namespace ChinaMan.ViewModels
{
    internal class WatchingMoviesViewModel : MovieListBaseViewModel
    {
        private ObservableCollection<string> _watchingMovies;
        public ObservableCollection<string> WatchingMovies
        {
            get => _watchingMovies;
            set => Set(ref _watchingMovies, value);
        }

        public WatchingMoviesViewModel() : base(typeof(WatchingMovieWindow))
        {
            _watchingMovies = new();
            WatchingMovies = new();
        }
    }
}
