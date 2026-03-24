using System.Collections.ObjectModel;
using ChinaMan.ViewModels.Base;
using ChinaMan.Views.Windows.AddRecordWindows;

namespace ChinaMan.ViewModels
{
    internal class WantToViewMovieViewModel : MovieListBaseViewModel
    {
        private ObservableCollection<string> _wantToViewMovies;
        public ObservableCollection<string> WantToViewMovies
        {
            get => _wantToViewMovies;
            set => Set(ref _wantToViewMovies, value);
        }

        public WantToViewMovieViewModel() : base(typeof(WantToViewMovieWindow))
        {
            _wantToViewMovies = new();
            WantToViewMovies = new();
        }
    }
}
