using System.ComponentModel;
using System.Linq;
using ReactiveUI;
using rush00.App.DataModel;

namespace rush00.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _contentViewModel;
        private Habit? _habit;

        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }

        public Habit? Habit
        {
            get => _habit;
            set
            {
                if (_habit != value)
                {
                    _habit?.ChallangeDays?.ToList().ForEach(hc => hc.PropertyChanged -= HabitCheckOnPropertyChanged);
                    this.RaiseAndSetIfChanged(ref _habit, value);
                    _habit?.ChallangeDays?.ToList().ForEach(hc => hc.PropertyChanged += HabitCheckOnPropertyChanged);
                    UpdateContentViewModel();
                }
            }
        }

        public MainWindowViewModel()
        {
            // HabitInitiallyLoader(); // TODO load habit from DB
            UpdateContentViewModel();
        }

        private void HabitCheckOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(HabitCheck.IsChecked) && _habit != null && _habit.IsFinished)
            {
                var congratulationsViewModel = new CongratulationsViewModel(_habit);
                congratulationsViewModel.ScreenPressed += LoadNewHabitCreator;
                ContentViewModel = congratulationsViewModel;
            }
        }

        private void LoadNewHabitCreator()
        {
            var newHabitViewModel = new NewHabitViewModel();
            newHabitViewModel.HabitCreated += OnHabitCreated;
            ContentViewModel = newHabitViewModel;
        }

        private void OnHabitCreated(Habit habit)
        {
            Habit = habit;
            UpdateContentViewModel();
        }

        private void UpdateContentViewModel()
        {
            if (ContentViewModel is CongratulationsViewModel oldCongratulationsViewModel)
            {
                oldCongratulationsViewModel.ScreenPressed -= LoadNewHabitCreator;
            }
            
            if (ContentViewModel is NewHabitViewModel oldHabitViewModel)
            {
                oldHabitViewModel.HabitCreated -= OnHabitCreated;
            }

            if (Habit == null || Habit.IsFinished)
            {
                var newHabitViewModel = new NewHabitViewModel();
                newHabitViewModel.HabitCreated += OnHabitCreated;
                ContentViewModel = newHabitViewModel;
            }
            else
            {
                ContentViewModel = new HabitCheckListViewModel(Habit);
            }
        }

    }
}
