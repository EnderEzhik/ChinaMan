using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ChinaMan.Models;

namespace ChinaMan.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public static MainViewModel Instance { get; private set; }

        private ObservableCollection<ViewedMovie> _viewedMovies;

        public ObservableCollection<ViewedMovie> ViewedMovies
        {
            get => _viewedMovies;
            set
            {
                _viewedMovies = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel()
        {
            Instance = this;
            _viewedMovies = new ObservableCollection<ViewedMovie>();
            ViewedMovies = new ObservableCollection<ViewedMovie>();
        }
    }
}
