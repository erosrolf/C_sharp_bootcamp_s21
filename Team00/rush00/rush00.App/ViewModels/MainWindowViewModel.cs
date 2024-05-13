using rush00.App.Services;

namespace rush00.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public HabitCheckListViewModel HabitCheckList { get; }
        
        public MainWindowViewModel()
        {
            var service = new HabitCheckListService();
            HabitCheckList = new HabitCheckListViewModel(service.GetItems());
        }
    }
}
