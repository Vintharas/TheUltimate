using System.Collections.Generic;
using TheUltimate.Domain.Model;

namespace TheUltimate.Services.Interfaces
{
    public interface ITaskHandler
    {
        IEnumerable<Task> GetTasks();
        Task CreateNewTask();
        void SaveTasks();
        Task FindTask(string keyword);
        void CompleteTask(Task task);
    }
}