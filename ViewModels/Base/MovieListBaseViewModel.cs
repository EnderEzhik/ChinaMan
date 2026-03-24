namespace ChinaMan.ViewModels.Base
{
    internal abstract class MovieListBaseViewModel : BaseViewModel
    {
        public System.Type WindowType;

        public MovieListBaseViewModel(System.Type windowType)
        {
            WindowType = windowType;
        }
    }
}
