using System;
using System.Collections.ObjectModel;
using rush00.Data.DataModel;

namespace rush00.App.ViewModels
{
    public class HabitCheckListViewModel : ViewModelBase
    {
        public ObservableCollection<HabitCheck> ListItems { get; }
        public Habit Habit { get; }
        
        public HabitCheckListViewModel(Habit habit)
        {
            Habit = habit;
            ListItems = new ObservableCollection<HabitCheck>(habit.ChallangeDays ?? Array.Empty<HabitCheck>());
        }
    }
}
