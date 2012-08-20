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
            throw new System.NotImplementedException();
        }

        public void CompleteTask(Task task)
        {
            throw new System.NotImplementedException();
        }
    }
}