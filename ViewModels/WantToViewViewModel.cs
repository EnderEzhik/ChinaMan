using System.Collections.ObjectModel;
using ChinaMan.ViewModels.Base;

namespace ChinaMan.ViewModels
{
    internal class WantToViewViewModel : BaseViewModel
    {
        private ObservableCollection<string> _wantToViewMovies;
        public ObservableCollection<string> WantToViewMovies
        {
            get => _wantToViewMovies;
            set => Set(ref _wantToViewMovies, value);
        }

        public WantToViewViewModel()
        {
            _wantToViewMovies = new();
            WantToViewMovies = new();
        }
    }
}
