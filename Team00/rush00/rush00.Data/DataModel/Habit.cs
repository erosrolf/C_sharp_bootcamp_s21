using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace rush00.Data.DataModel
{
    public class Habit
    {
        [Key]
        public int Id { get; set; }
        public string Title { get;  set; }
        public string Motivation { get;  set; }
        public DateTimeOffset? StartDate { get;  set; }
        public IEnumerable<HabitCheck>? ChallangeDays { get; private set; }
        public bool IsFinished => !IsActual() || LastDayIsChecked();

        public Habit(string title, string motivation, DateTimeOffset? startDate)
        {
            if (startDate == null)
            {
                throw new Exception("");
            }
            Title = title;
            Motivation = motivation;
            StartDate = startDate;
        }
        public Habit(string title, string motivation, DateTimeOffset? startDate, int challangeDays)
        {
            if (startDate == null)
            {
                throw new Exception("");
            }
            Title = title;
            Motivation = motivation;
            StartDate = startDate;

            var checks = new List<HabitCheck>();
            for (int i = 0; i < challangeDays; i++)
            {
                checks.Add(new HabitCheck { IsChecked = false, Date = startDate.Value.AddDays(i) });
            }

            ChallangeDays = checks;
        }

        private bool LastDayIsChecked()
        {
            return ChallangeDays?.LastOrDefault()?.IsChecked ?? true;
        }

        private bool IsActual()
        {
            return ChallangeDays?.LastOrDefault()?.Date.DayOfYear >= DateTimeOffset.Now.DayOfYear;
        }
    }
}