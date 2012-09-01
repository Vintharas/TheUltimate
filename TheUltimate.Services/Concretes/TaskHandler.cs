using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using TheUltimate.Domain.Model;
using TheUltimate.Services.Interfaces;
using TheUltimate.Storage;
using System.Linq;

namespace TheUltimate.Services.Concretes
{
    public class TaskHandler : ITaskHandler
    {
        private readonly IContext context;

        public TaskHandler(IContext context)
        {
            this.context = context;
        }

        public IEnumerable<Task> GetTasks()
        {
            return context.Tasks.ToList();
        }

        public Task CreateNewTask()
        {
            //TO DO: need to add identifier to task
            Task task = new Task();
            task.Number = context.Tasks.Count() + 1;
            context.Tasks.Add(task);
            return task;
        }

        public void SaveTasks()
        {
            context.SaveChanges();
        }

        public Task FindTask(string keyword)
        {
            if (keyword.IsANumber())
            {
                int taskNumber;
                int.TryParse(keyword.Replace("#", ""), out taskNumber);
                return context.Tasks.Single(t => t.Number == taskNumber);
            }
            return context.Tasks.Single(t => t.Name == keyword);
        }

        public void CompleteTask(Task task)
        {
            task.Status = Status.Completed;
        }
    }

    public static class TaskHandlerHelperExtensions
    {
        public static bool IsANumber(this string keyword)
        {
            return Regex.IsMatch(keyword, pattern: @"#\d+");  // Anything like #1, #12, #122 matches
        }
    }
}