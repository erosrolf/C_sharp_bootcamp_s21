using rush00.Data.DataModel;

namespace rush00.Data
{
    public interface DAOHabitRepository
    {
        public Habit? getActual();

        public void addHabit(Habit habit);

        public void removeHabit(Habit habit);

        public List<Habit>? getAllHabit();

        public void updateHabit(Habit habit);
    }
}
