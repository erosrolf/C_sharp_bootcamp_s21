using Microsoft.EntityFrameworkCore;
using rush00.Data.DataModel;


namespace rush00.Data
{
    public class HabitRepository : DAOHabitRepository
    {
        private HabitDbContext _db;
        public HabitRepository(HabitDbContext db)
        {
            _db = db;
        }
        public void addHabit(Habit habit)
        {
           _db.Add(habit);
            foreach(var i in habit.ChallangeDays)
            {
                _db.Add(i);
            }
            _db.SaveChanges();
        }

        public Habit? getActual()
        {
           var h = getAllHabit();
           return h.Where(h => !h.IsFinished).FirstOrDefault(defaultValue: null);
        }
        public List<Habit>? getAllHabit() => _db.Habits.Include(x => x.ChallangeDays).ToList();

        public void removeHabit(Habit habit)
        {
            _db.HabitChecks.Where(x => x.Habit.Id == habit.Id).ExecuteDelete();
            _db.Habits.Where(x => x.Id == habit.Id).ExecuteDelete();
        }
        

        public void updateHabit(Habit habit) {
            _db.Habits.Where(x => x.Id == habit.Id).ExecuteUpdate(x => x
            .SetProperty(u => u.Title, u => habit.Title)
            .SetProperty(u => u.Motivation, u => habit.Motivation)
            .SetProperty(u => u.StartDate, u => habit.StartDate)
            );

            foreach (var item in habit.ChallangeDays)
            {
                _db.HabitChecks.Where(x => x.HabitId == habit.Id && x.Id == item.Id).ExecuteUpdate(x => x.SetProperty(c => c.IsChecked, c => c.IsChecked == item.IsChecked));
            }
        }
    
    }
}
