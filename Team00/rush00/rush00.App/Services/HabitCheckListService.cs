using System.Collections.Generic;
using rush00.App.DataModel;

namespace rush00.App.Services
{
    public class HabitCheckListService
    {
        public IEnumerable<HabitCheck> GetItems(Habit habit)
        {
            return habit.ChallangeDays ?? new List<HabitCheck>();
        }
    }
}
