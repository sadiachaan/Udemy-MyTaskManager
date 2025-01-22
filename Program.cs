// See https://aka.ms/new-console-template for more information
using System;

namespace MyTaskManager;

class Program
{
    static void Main(string[] args)
    {
    List<Task> taskList = new List<Task>();
        //Initial sample task
        taskList.Add(new Task(1, "C# 12 project", DateTime.Now.AddDays(3)));

         DisplayMenu();

        while(true)
        {
            Console.WriteLine("Enter your choice: ");
            string choice = Console.ReadLine();
            switch (choice) {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ReadTasks();
                    break;
                case"3":
                    MarkAsCompleted();
                    break;
                case "4":
                    Console.WriteLine("Exiting...")
                    return;
                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }


        Console.WriteLine("");
    }


        private static void AddTask()
    {
        int taskId = taskList.Count+ 1 ;
        Console.WriteLine("Enter task description : ");
        string description = Console.ReadLine();
        Console.Write("Enter due date (YYYY-MM-DD): ");
        DateTime dueDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Task Added!");
    }

    void ReadTask()
    {
        Console.WriteLine("***Task List***");
        Console.WriteLine("Task ID Description");
        Console.WriteLine();
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("****My Task Manager****");
        Console.WriteLine("1. Add Task");
        Console.WriteLine("2. Read Tasks");
        Console.WriteLine("3. Mark task as Completed.");
        Console.WriteLine("4. Exit");
    }
}