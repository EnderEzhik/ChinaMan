using System.Collections.ObjectModel;
using ChinaMan.ViewModels.Base;

namespace ChinaMan.ViewModels
{
    internal class AbandonedMoviesViewModel : BaseViewModel
    {
        public class AbandonedMovie : BaseViewModel
        {
            private string _title;
            public string Title
            {
                get => _title;
                set => Set(ref _title, value);
            }

            private string _description;
            public string Description
            {
                get => _description;
                set => Set(ref _description, value);
            }
        }

        private ObservableCollection<AbandonedMovie> _abandonedMovies;
        public ObservableCollection<AbandonedMovie> AbandonedMovies
        {
            get => _abandonedMovies;
            set => Set(ref _abandonedMovies, value);
        }

        public AbandonedMoviesViewModel()
        {
            _abandonedMovies = new();
            AbandonedMovies = new();
        }
    }
}
