// See https://aka.ms/new-console-template for more information
using System;

namespace MyTaskManager;

class Program
{
    static List<Task> taskList = new List<Task>();

    static void Main(string[] args)
    {
        // Initial sample task
        taskList.Add(new Task(1, "C# 12 project", DateTime.Now.AddDays(3)));

        DisplayMenu();

        while (true)
        {
            Console.WriteLine("Enter your choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ReadTask();
                    break;
                case "3":
                     MarkAsCompleted();
                    break;
                case "4":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }

        }
    }

    private static void AddTask()
    {
        int taskId = taskList.Count + 1;
        Console.Write("Enter task description: ");
        string description = Console.ReadLine();
        Console.Write("Enter due date (YYYY-MM-DD): ");
        DateTime dueDate = DateTime.Parse(Console.ReadLine());
        taskList.Add(new Task(taskId, description, dueDate));
        Console.WriteLine("Task Added!");
    }

    private static void ReadTask()
    {
        if (taskList.Count == 0)
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        Console.WriteLine("*** Task List ***");
        Console.WriteLine("Task ID | Description | Due Date | Completed");
        Console.WriteLine("----------------------------------------");

        foreach (Task task in taskList)
        {
            string status = task.IsComplete ? "Yes" : "No";
            Console.WriteLine($"{task.TaskId} |  {task.Description} |  {task.DueDate.Year} |  {task.DueDate:MM} |  {task.DueDate:dd} |  {status}");
        }

        Console.Write("Enter sorting criteria (id, description, due date, completed): ");
        string sortBy = Console.ReadLine();

        SortTask(sortBy);

    }

    private static void SortTask(string sortBy)
    {
        switch (sortBy.ToLower())
        {
            case "id":
                taskList.Sort((t1,t2) => t1.TaskId.CompareTo(t2.TaskId)); 
                break;
            case "description":
                taskList.Sort((t1, t2) => t1.Description.CompareTo(t2.Description));
                break;
            case "due date":
                taskList.Sort((t1, t2) => t1.DueDate.CompareTo(t2.DueDate));
                break;
            case "completed":
                taskList.Sort((t1, t2) => t1.IsComplete.CompareTo(t2.IsComplete));
                break;
        }
    }

    private static void MarkAsCompleted()
    {
        //Get the task ID from the user 
        Console.Write("Enter task Id: ");
        // Handle potential parsing errors
        int taskID = Convert.ToInt32(Console.ReadLine());

        Task taskToMark = taskList.Find(task => task.TaskId == taskID);

        //Check if Task exists
        if(taskToMark == null)
        {
            Console.WriteLine("task doesn't Exist!");
            return;
        }

        taskToMark.IsComplete = true;
        Console.WriteLine($"The task {taskID} has been completed!");
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("**** My Task Manager ****");
        Console.WriteLine("1. Add Task");
        Console.WriteLine("2. Read Tasks");
        Console.WriteLine("3. Mark task as Completed");
        Console.WriteLine("4. Exit");
    }
}


