using System.Collections.ObjectModel;
using ChinaMan.ViewModels.Base;
using ChinaMan.ViewModels.Items;

namespace ChinaMan.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public static MainViewModel Instance { get; private set; }

        #region Просмотренные фильмы
        private ObservableCollection<FilmInfoViewModel> _filmInfoList;

        /// <summary>
        /// Список просмотренных фильмов
        /// </summary>
        public ObservableCollection<FilmInfoViewModel> FilmInfoList
        {
            get => _filmInfoList;
            set => Set(ref _filmInfoList, value);
        }
        #endregion

        public MainViewModel()
        {
            Instance = this;
            _filmInfoList = new();
            FilmInfoList = new();
        }
    }
}
