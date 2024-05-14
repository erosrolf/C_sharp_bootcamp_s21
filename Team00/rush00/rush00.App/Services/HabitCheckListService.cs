using System;
using System.Collections.Generic;
using rush00.App.DataModel;

namespace rush00.App.Services
{
    public class HabitCheckListService
    {
        // public IEnumerable<HabitCheck> GetItems() => new[]
        // {
        //     new HabitCheck { IsChecked = true, Date = new DateTime() },
        //     new HabitCheck { IsChecked = false, Date = new DateTime(2024, 7, 20) },
        // };
        
        public IEnumerable<HabitCheck> GetItems(Habit habit)
        {
            var checks = new List<HabitCheck>();
            for (int i = 0; i < habit.ChallangeDays; i++)
            {
                checks.Add(new HabitCheck
                {
                    IsChecked = false, Date = habit.StartDate.Value.AddDays(i)
                });
            }

            return checks;
        }
    }
}
