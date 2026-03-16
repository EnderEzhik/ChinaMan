using System.Collections.ObjectModel;
using ChinaMan.ViewModels.Base;
using ChinaMan.ViewModels.Items;

namespace ChinaMan.ViewModels
{
    internal class ViewedMoviesViewModel : MovieListBaseViewModel
    {
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

        public ViewedMoviesViewModel() : base(typeof(ViewedMovieWindow))
        {
            _viewedMoviesList = new();
            ViewedMoviesList = new();
        }
    }
}
