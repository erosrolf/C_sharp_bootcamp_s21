﻿using ReactiveUI;
using rush00.App.DataModel;
using rush00.App.Services;

namespace rush00.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _contentViewModel;
        public HabitCheckListViewModel? HabitCheckList { get; }
        public NewHabitViewModel NewHabitView { get;  }
        
        public MainWindowViewModel()
        {
            NewHabitView = new NewHabitViewModel();
            NewHabitView.HabitCreated += OnHabitCreated;
            _contentViewModel = NewHabitView;
        }

        private void OnHabitCreated(Habit habit)
        {
            var service = new HabitCheckListService();
            ContentViewModel = new HabitCheckListViewModel(service.GetItems(habit));
        }

        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }
    }
}
