using rush00.Data.DataModel;

namespace rush00.Data
{
    public interface DAOHabitRepository
    {
        public Habit? GetActual();

        public void AddHabit(Habit habit);

        public void RemoveHabit(Habit habit);

        public List<Habit>? GetAllHabit();

        public void UpdateHabit(Habit habit);
    }
}
