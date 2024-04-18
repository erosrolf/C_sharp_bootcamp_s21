using System.Data;

public class TaskManager
{
    private List<Task> _tasks = new List<Task>();

    public void AddNewTask()
    {
        Console.WriteLine("add");
        var title = Console.ReadLine();
        if (string.IsNullOrEmpty(title))
        {
            title = "NUN";
        }
        Console.WriteLine("Enter a description");
        var description = Console.ReadLine();
        if (string.IsNullOrEmpty(description))
        {
            description = "NUN";
        }
        Console.WriteLine("Enter the deadline");
        DateTime deadline = new DateTime(1992, 02, 02);
        TaskType type = TaskType.Word;
        TaskPriority priority = TaskPriority.High;


        _tasks.Add(new Task(title, description, deadline, type, priority));
        Console.WriteLine(deadline);
    }
}
