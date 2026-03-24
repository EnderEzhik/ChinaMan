using System.Windows.Controls;
using ChinaMan.ViewModels.Base;

namespace ChinaMan.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private TabItem _currentTabItem;
        public TabItem CurrentTabItem
        {
            get => _currentTabItem;
            set => Set(ref _currentTabItem, value);
        }
    }
}
