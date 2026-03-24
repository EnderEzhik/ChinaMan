using ChinaMan.ViewModels.Base;

namespace ChinaMan.ViewModels.Items
{
    public class AbandonedMovieViewModel : BaseViewModel
    {
        public string Title { get; set; }

        private string _abandonReason;
        public string AbandonReason
        {
            get => _abandonReason;
            set => Set(ref _abandonReason, value);
        }
    }
}
