using Microsoft.EntityFrameworkCore;
using rush00.Data.DataModel;


namespace rush00.Data
{
    public class HabitRepository : DAOHabitRepository
    {
        private readonly HabitDbContext _db;
        public HabitRepository(HabitDbContext db)
        {
            _db = db;
        }
        
        public void AddHabit(Habit? habit)
        {
            Console.WriteLine("AddHabit");
            if (habit is { ChallangeDays: not null })
            {
               _db.Add(habit);
               foreach (var i in habit.ChallangeDays)
               {
                   _db.Add(i);
               }
               _db.SaveChanges();
            }
        }

        public Habit? GetActual()
        { 
            Console.WriteLine("GetActual");
            var h = GetAllHabit();
            return h.Where(h => !h.IsFinished).FirstOrDefault(defaultValue: null);
        }
        public List<Habit>? GetAllHabit() => _db.Habits.Include(x => x.ChallangeDays).ToList();
        
        public void RemoveHabit(Habit habit)
        {
            var habitChecksToRemove = _db.HabitChecks.Where(x => x.Habit.Id == habit.Id);
            _db.HabitChecks.RemoveRange(habitChecksToRemove);

            var habitToRemove = _db.Habits.SingleOrDefault(x => x.Id == habit.Id);
            if (habitToRemove != null)
            {
                _db.Habits.Remove(habitToRemove);
            }

            _db.SaveChanges();
        }

        public void UpdateHabit(Habit habit) 
        {
            Console.WriteLine("Update Habit");
            var habitToUpdate = _db.Habits.SingleOrDefault(x => x.Id == habit.Id);
            if (habitToUpdate != null)
            {
                habitToUpdate.Title = habit.Title;
                habitToUpdate.Motivation = habit.Motivation;
                habitToUpdate.StartDate = habit.StartDate;

                foreach (var item in habit.ChallangeDays)
                {
                    var habitCheckToUpdate = _db.HabitChecks.SingleOrDefault(x => x.HabitId == habit.Id && x.Id == item.Id);
                    if (habitCheckToUpdate != null)
                    {
                        habitCheckToUpdate.IsChecked = item.IsChecked;
                    }
                }

                _db.SaveChanges();
            }
        }
    }
}
