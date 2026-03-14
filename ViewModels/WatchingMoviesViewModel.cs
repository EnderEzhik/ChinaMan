using System.Collections.ObjectModel;
using ChinaMan.ViewModels.Base;

namespace ChinaMan.ViewModels
{
    internal class WatchingMoviesViewModel : BaseViewModel
    {
        private ObservableCollection<string> _watchingMovies;
        public ObservableCollection<string> WatchingMovies
        {
            get => _watchingMovies;
            set => Set(ref _watchingMovies, value);
        }

        public WatchingMoviesViewModel()
        {
            _watchingMovies = new();
            WatchingMovies = new();
        }
    }
}
