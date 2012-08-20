using System.Collections.Generic;
using TheUltimate.Domain.Model;

namespace TheUltimate.Services.Interfaces
{
    public interface ITaskHandler
    {
        IEnumerable<Task> GetTasks();
        Task CreateNewTask();
        void CompleteTask(Task task);
    }
}