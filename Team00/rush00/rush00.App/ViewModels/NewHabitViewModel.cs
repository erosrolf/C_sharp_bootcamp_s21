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
        private decimal? _challengeDays;

        public event Action<Habit>? HabitCreated;
        public ReactiveCommand<Unit, Unit> StartCommand{ get; }

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

        public decimal? ChallengeDays
        {
            get => _challengeDays == null ? 0 : decimal.ToInt32(_challengeDays.Value);
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

            StartCommand = ReactiveCommand.Create(
                execute: () =>
                {
                    Habit newHabit = StartHabit();
                    HabitCreated?.Invoke(newHabit);
                },
                canExecute: canStart);
        }

        private Habit StartHabit()
        {
            var habit = new Habit(Title, Motivation, StartDate, Convert.ToInt32(ChallengeDays));
            return habit;
        }
    }
}