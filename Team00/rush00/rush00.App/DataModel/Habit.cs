using System;

namespace rush00.App.DataModel
{
    public class Habit
    {
        public string Title { get; set; } = String.Empty;
        public string Motivation { get; set; } = String.Empty;
        public DateTime StartDate { get; set; }
        public int ChallangeDays { get; set; }
    }
}
