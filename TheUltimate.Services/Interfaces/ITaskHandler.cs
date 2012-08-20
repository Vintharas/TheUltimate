using TheUltimate.Domain.Model;

namespace TheUltimate.Services.Interfaces
{
    public interface ITaskHandler
    {
        Task CreateNewTask();
        void CompleteTask(Task task);
    }
}