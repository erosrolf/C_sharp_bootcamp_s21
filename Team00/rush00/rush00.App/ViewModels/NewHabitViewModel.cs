using System;
using System.Reactive;
using rush00.App.DataModel;
using ReactiveUI;

namespace rush00.App.ViewModels
{
    public class NewHabitViewModel : ViewModelBase
    {
        private Habit _newHabit = new Habit();
        private string _title;
        private string _motivation;
        private DateTime _startDate;
        private int _challengeDays;

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

        public DateTime StartDate
        {
            get => _startDate;
            set => this.RaiseAndSetIfChanged(ref _startDate, value);
        }

        public int ChallengeDays
        {
            get => _challengeDays;
            set => this.RaiseAndSetIfChanged(ref _challengeDays, value);
        }

        public ReactiveCommand<Unit, Habit> StartCommand{ get; }

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
                    startDate >= DateTime.Now && 
                    challengeDays > 0);
        }

        private Habit StartHabit()
        {
            return new Habit
            {
                Title = Title,
                Motivation = Motivation,
                StartDate = StartDate,
                ChallangeDays = ChallengeDays
            };
        }
    }
}
    
