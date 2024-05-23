using Microsoft.EntityFrameworkCore;
using rush00.Data.DataModel;

namespace rush00.Data;

public class HabitDbContext : DbContext
{
    public DbSet<Habit> Habits => Set<Habit>();
    public DbSet<HabitCheck> HabitChecks => Set<HabitCheck>();
    public HabitDbContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=habits.db");
    }
}