using System.Collections.ObjectModel;
using ChinaMan.ViewModels.Base;
using ChinaMan.ViewModels.Items;

namespace ChinaMan.ViewModels
{
    internal class ViewedMoviesViewModel : BaseViewModel
    {
        public static ViewedMoviesViewModel Instance { get; private set; }

        #region Просмотренные фильмы
        private ObservableCollection<ViewedMovieViewModel> _viewedMoviesList;

        /// <summary>
        /// Список просмотренных фильмов
        /// </summary>
        public ObservableCollection<ViewedMovieViewModel> ViewedMoviesList
        {
            get => _viewedMoviesList;
            set => Set(ref _viewedMoviesList, value);
        }
        #endregion

        public ViewedMoviesViewModel()
        {
            Instance = this;
            _viewedMoviesList = new();
            ViewedMoviesList = new();
        }
    }
}
