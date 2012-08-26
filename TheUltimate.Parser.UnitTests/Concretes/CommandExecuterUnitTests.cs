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
            var command = new Command
                {
                    Verb = "create new task",
                    Argument = "do the laundry",
                    Line = "create new task do the laundry",
                    Response = "created new task!",
                    IsValid = true
                };
            taskHandler.Setup(t => t.CreateNewTask()).Returns(new Task());
            var executer = GetExecuter();
            // Act
            executer.Execute(command);
            // Assert
            taskHandler.Verify(t => t.CreateNewTask());
            taskHandler.Verify(t => t.SaveTasks());
        }

        private CommandExecuter GetExecuter()
        {
            return new CommandExecuter(taskHandler.Object);
        }
    }
}