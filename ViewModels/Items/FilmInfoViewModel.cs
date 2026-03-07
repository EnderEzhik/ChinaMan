using ChinaMan.ViewModels.Base;

namespace ChinaMan.ViewModels.Items
{
    internal class FilmInfoViewModel : BaseViewModel
    {
        public string Title { get; set; }

        private DateTime _lastWatchedDate;
        public DateTime LastWatchedDate
        {
            get => _lastWatchedDate;
            set => Set(ref _lastWatchedDate, value);
        }

        private float _avgRating;
        public float AvgRating
        {
            get => _avgRating;
            set => Set(ref _avgRating, value);
        }

        private int _viewsCount;
        public int ViewsCount
        {
            get => _viewsCount;
            set => Set(ref _viewsCount, value);
        }
    }
}
