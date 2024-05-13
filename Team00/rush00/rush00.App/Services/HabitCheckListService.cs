using System;
using System.Collections.Generic;
using rush00.App.DataModel;

namespace rush00.App.Services
{
    public class HabitCheckListService
    {
        public IEnumerable<HabitCheck> GetItems() => new[]
        {
            new HabitCheck { IsChecked = true, Date = new DateTime() },
            new HabitCheck { IsChecked = false, Date = new DateTime(2024, 7, 20) },
        };
    }
}
