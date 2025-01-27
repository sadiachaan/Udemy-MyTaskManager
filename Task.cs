using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace MyTaskManager
{
    public class Task
    {
        public int TaskId;
        public string Description;
        public DateTime DueDate;
        public bool IsComplete;

        //Add constructor to simplify task Creation
        public Task(int taskId, string description, DateTime dueDate)
        {
            TaskId = taskId;
            Description = description;
            DueDate = dueDate;
            IsComplete = false;
        }
    }
}
