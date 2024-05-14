using System;
using System.Reactive;
using rush00.App.DataModel;
using ReactiveUI;

namespace rush00.App.ViewModels
{
    public class NewHabitViewModel : ViewModelBase
    {
        private string _title = String.Empty;
        private string _motivation = String.Empty;
        private DateTimeOffset? _startDate = DateTimeOffset.Now;
        private int _challengeDays;
        
        public ReactiveCommand<Unit, Habit> StartCommand{ get; }
        public event Action<Habit> HabitCreated;

        public string Title
        {
            get => _title;
            set => this.RaiseAndSetIfChanged(ref _title, value);
        }

        public string Motivation
        {
            get => _motivation;
            set => this.RaiseAndSetIfChanged(ref _motivation, value);
        }

        public DateTimeOffset? StartDate
        {
            get => _startDate;
            set => this.RaiseAndSetIfChanged(ref _startDate, value);
        }

        public int ChallengeDays
        {
            get => _challengeDays;
            set => this.RaiseAndSetIfChanged(ref _challengeDays, value);
        }

        public NewHabitViewModel()
        {
            var canStart = this.WhenAnyValue(
                x => x.Title,
                x => x.Motivation,
                x => x.StartDate,
                x => x.ChallengeDays,
                (title, motivation, startDate, challengeDays) => 
                    !string.IsNullOrWhiteSpace(title) &&
                    !string.IsNullOrWhiteSpace(motivation) &&
                    startDate != null &&
                    startDate >= DateTimeOffset.Now.Date && 
                    challengeDays > 0);
            
            StartCommand = ReactiveCommand.Create(StartHabit, canStart);
        }

        private Habit StartHabit()
        {
            var habit = new Habit
            {
                Title = Title,
                Motivation = Motivation,
                StartDate = StartDate,
                ChallangeDays = ChallengeDays
            };
            HabitCreated?.Invoke(habit);
            return habit;
        }
    }
}