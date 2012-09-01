using Moq;
using NUnit.Framework;
using TheUltimate.Domain.Model;
using TheUltimate.Interpreter.Concretes;
using TheUltimate.Interpreter.Model;
using TheUltimate.Services.Interfaces;

namespace TheUltimate.Interpreter.UnitTests.Concretes
{
    [TestFixture]
    public class CommandExecuterUnitTests
    {
        private Mock<ITaskHandler> taskHandler;

        [SetUp]
        public void SetUp()
        {
            taskHandler = new Mock<ITaskHandler>();
        }

        [Test]
        public void Execute_WhenGivenACreateNewTaskCommand_ShouldCreateANewTaskViaTheTaskHandler()
        {
            // Arrange
            var newTask = new Task();
            var command = new Command
                {
                    Verb = "create new task",
                    Argument = "do the laundry",
                    Line = "create new task do the laundry",
                    Response = "created new task!",
                    IsValid = true
                };
            taskHandler.Setup(t => t.CreateNewTask()).Returns(newTask);
            var executer = GetExecuter();
            // Act
            executer.Execute(command);
            // Assert
            taskHandler.Verify(t => t.CreateNewTask());
            taskHandler.Verify(t => t.SaveTasks());
        }

        [Test]
        public void Execute_WhenGivenACreateNewTaskCommand_ShouldAddTheAffectedTaskToTheCommand()
        {
            // Arrange
            var newTask = new Task();
            var command = new Command
            {
                Verb = "create new task",
                Argument = "do the laundry",
                Line = "create new task do the laundry",
                Response = "created new task!",
                IsValid = true
            };
            taskHandler.Setup(t => t.CreateNewTask()).Returns(newTask);
            var executer = GetExecuter();
            // Act
            executer.Execute(command);
            // Assert
            Assert.AreSame(expected: newTask, actual: command.AffectedTask);
        }

        [Test]
        public void Execute_WhenGivenCompleteTaskCommand_ShouldCompleteTheTaskViaTheTaskHandler()
        {
            // Arrange
            var taskToComplete = new Task();
            var command = new Command
                {
                    Verb = "complete task",
                    Argument = "do the laundry",
                    Line = "complete task do the laundry",
                    Response = "task completed!",
                    IsValid = true
                };
            taskHandler.Setup(x => x.FindTask(command.Argument)).Returns(taskToComplete);
            taskHandler.Setup(x => x.CompleteTask(taskToComplete));
            // Act
            GetExecuter().Execute(command);
            // Assert
            taskHandler.Verify(x => x.FindTask(command.Argument));
            taskHandler.Verify(x => x.CompleteTask(taskToComplete));
        }

        private CommandExecuter GetExecuter()
        {
            return new CommandExecuter(taskHandler.Object);
        }
    }
}