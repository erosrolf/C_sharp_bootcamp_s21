using System;
using System.Collections.Generic;
using System.Linq;

namespace rush00.Data.DataModel
{
    public class Habit
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Motivation { get; private set; }
        public DateTimeOffset? StartDate { get; private set; }
        public IEnumerable<HabitCheck>? ChallangeDays { get; private set; }
        public bool IsFinished => AllDaysDone();

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

        private bool AllDaysDone()
        {
            return ChallangeDays == null || ChallangeDays.LastOrDefault().IsChecked;
        }
    }
}