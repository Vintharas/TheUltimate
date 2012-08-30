using System.Collections.Generic;
using TheUltimate.Domain.Model;
using TheUltimate.Services.Interfaces;
using TheUltimate.Storage;

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
            return context.Tasks;
        }

        public Task CreateNewTask()
        {
            //TO DO: need to add identifier to task
            Task task = new Task();
            task.Number = context.Tasks.Count + 1;
            context.Tasks.Add(task);
            return task;
        }

        public void SaveTasks()
        {
            context.SaveContext();
        }

        public void CompleteTask(Task task)
        {
            throw new System.NotImplementedException();
        }
    }
}