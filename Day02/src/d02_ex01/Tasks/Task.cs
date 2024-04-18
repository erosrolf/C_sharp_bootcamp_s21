public class Task
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime Deadline { get; private set; }
    public TaskType Type { get; private set; }
    public TaskPriority Priority { get; private set; }
    public TaskState State { get; private set; }
    public Task(string title, string description, DateTime deadline,
                TaskType type, TaskPriority priority)
    {
        Title = title;
        Description = description;
        Deadline = deadline;
        Type = type;
        Priority = priority;
        State = TaskState.New;
    }

    public void MarkAsCompleted()
    {
        if (State == TaskState.New)
        {
            State = TaskState.Completed;
        }
    }

    public void MarkAsIrrelevant()
    {
        if (State == TaskState.New)
        {
            State = TaskState.Irrelevant;
        }
    }
}
