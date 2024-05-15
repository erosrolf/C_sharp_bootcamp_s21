using System;
using System.Reactive;
using rush00.App.DataModel;
using ReactiveUI;
using rush00.App.Services;

namespace rush00.App.ViewModels
{
    public class NewHabitViewModel : ViewModelBase
    {
        private string _title = String.Empty;
        private string _motivation = String.Empty;
        private DateTimeOffset? _startDate = DateTimeOffset.Now;
        private int _challengeDays;

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
            var service = new HabitCheckListService();
            var habit = new Habit(Title, Motivation, StartDate, ChallengeDays);
            return habit;
        }
    }
}