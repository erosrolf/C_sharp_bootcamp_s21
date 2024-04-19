using System.Runtime.CompilerServices;

public class Task
{
    public string Title { get; private set; }
    public string? Summary { get; private set; }
    public DateTime? DueDate { get; private set; }
    public TaskType Type { get; private set; }
    public TaskPriority Priority { get; private set; }
    public TaskState State { get; private set; }

    public Task(string title, TaskType type, DateTime? dueDate = null, string? summary = null,
                 TaskPriority priority = TaskPriority.Normal)
    {
        Title = title;
        Summary = summary;
        DueDate = dueDate;
        Type = type;
        Priority = priority;
        State = TaskState.New;
    }

    public override string ToString()
    {
        if (DueDate == null)
        {
            return $"- {Title}\n" +
                   $"[{Type}] [{State}]\n" +
                   $"Priority: {Priority}\n" +
                   $"{Summary}";

        }
        return $"- {Title}\n" +
               $"[{Type}] [{State}]\n" +
               $"Priority: {Priority}, Due till {DueDate}\n" +
               $"{Summary}";
    }

    public bool MarkAsCompleted()
    {
        if (State == TaskState.New)
        {
            State = TaskState.Completed;
            return true;
        }
        return false;
    }

    public bool MarkAsIrrelevant()
    {
        if (State == TaskState.New)
        {
            State = TaskState.Irrelevant;
            return true;
        }
        return false;
    }
}
