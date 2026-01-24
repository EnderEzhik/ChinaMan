using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ChinaMan.Models;
using ChinaMan.ViewModels.Base;

namespace ChinaMan.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public static MainViewModel Instance { get; private set; }

        #region Просмотренные фильмы
        private ObservableCollection<ViewedMovie> _viewedMovies;

        /// <summary>
        /// Список просмотренных фильмов
        /// </summary>
        public ObservableCollection<ViewedMovie> ViewedMovies
        {
            get => _viewedMovies;
            set => Set(ref _viewedMovies, value);
        }
        #endregion

        public MainViewModel()
        {
            Instance = this;
            _viewedMovies = new ObservableCollection<ViewedMovie>();
            ViewedMovies = new ObservableCollection<ViewedMovie>();
        }
    }
}
