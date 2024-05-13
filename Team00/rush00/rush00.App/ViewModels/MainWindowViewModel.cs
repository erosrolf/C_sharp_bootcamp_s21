using ReactiveUI;
using rush00.App.Services;

namespace rush00.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _contentViewModel;
        public HabitCheckListViewModel HabitCheckList { get; }
        
        public MainWindowViewModel()
        {
            var service = new HabitCheckListService();
            HabitCheckList = new HabitCheckListViewModel(service.GetItems());
            _contentViewModel = HabitCheckList;
        }

        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }
    }
}
