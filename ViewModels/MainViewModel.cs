using System.Collections.ObjectModel;
using ChinaMan.Database.Models;
using ChinaMan.ViewModels.Base;

namespace ChinaMan.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public static MainViewModel Instance { get; private set; }

        #region Просмотренные фильмы
        private ObservableCollection<Film> _films;

        /// <summary>
        /// Список просмотренных фильмов
        /// </summary>
        public ObservableCollection<Film> Films
        {
            get => _films;
            set => Set(ref _films, value);
        }
        #endregion

        public MainViewModel()
        {
            Instance = this;
            _films = new();
            Films = new();
        }
    }
}
