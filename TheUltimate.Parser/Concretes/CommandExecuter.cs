using System;
using TheUltimate.Domain.Model;
using TheUltimate.Interpreter.Interfaces;
using TheUltimate.Interpreter.Model;
using TheUltimate.Services.Interfaces;

namespace TheUltimate.Interpreter.Concretes
{
    public class CommandExecuter : ICommandExecuter
    {
        private readonly ITaskHandler taskHandler;

        public CommandExecuter(ITaskHandler taskHandler)
        {
            this.taskHandler = taskHandler;
        }

        public void Execute(Command command)
        {
            // This has to be refactoring, it is not extensible AT ALL! ^_^
            if (command.IsCreateNewTask())
                CreateNewTask(command);
        }

        private void CreateNewTask(Command command)
        {
            Task task = taskHandler.CreateNewTask();
            task.Name = command.Argument;
            taskHandler.SaveTasks();
        }
    }
}

public static class CommandExtensions
{
    public static bool IsCreateNewTask(this Command command)
    {
        return (command.Verb == "create new task" || command.Verb == "new task");
    }
}