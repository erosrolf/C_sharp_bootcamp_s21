using System.Collections.Generic;
using System.Collections.ObjectModel;
using rush00.App.DataModel;

namespace rush00.App.ViewModels
{
    public class HabitCheckListViewModel : ViewModelBase
    {
        public ObservableCollection<HabitCheck> ListItems { get; }
        
        public HabitCheckListViewModel(IEnumerable<HabitCheck> items)
        {
            ListItems = new ObservableCollection<HabitCheck>(items);
        }
    }
}