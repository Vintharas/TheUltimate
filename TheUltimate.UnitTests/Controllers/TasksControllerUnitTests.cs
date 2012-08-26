using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TheUltimate.Controllers;
using TheUltimate.Domain.Model;
using TheUltimate.Interpreter.Interfaces;
using TheUltimate.Interpreter.Model;
using TheUltimate.Models;
using TheUltimate.Services.Interfaces;

namespace TheUltimate.UnitTests.Controllers
{
    [TestFixture]
    public class TasksControllerUnitTests
    {
        private Mock<ITaskHandler> taskHandler;
        private Mock<IInterpreter> interpreter;

        [SetUp]
        public void SetUp()
        {
            taskHandler = new Mock<ITaskHandler>();
            interpreter = new Mock<IInterpreter>();
        }

        [Test]
        public void Index_WhenAUserHasASeriesOfTasksToDo_ShouldGetThisTasksAndPassThemToTheView()
        {
            // Arrange
            var tasks = new List<Task> {new Task { Name = "Do the dishes"}, new Task { Name = "Vacuum Clean"}};
            taskHandler.Setup(t => t.GetTasks()).Returns(tasks);
            var taskController = GetTaskController();
            // Act
            var view = taskController.Index();
            // Assert
            Assert.AreEqual(expected: tasks, actual: view.Model);
        }

        [Test]
        public void InterpretCommand_WhenGivenACommand_ShouldInterpretItUsingTheInterpreter()
        {
            // Arrange
            var command = new CommandViewModel {Line = "create new task go to the doctor"};
            var tasksController = GetTaskController();
            // Act
            tasksController.InterpretCommand(command);
            // Assert
            interpreter.Verify(x => x.Interpret(command.Line));
        }

        [Test]
        public void InterpretCommand_WhenGivenACommandAndInterpretingIt_ShouldReturnJsonSerializedCommandResultOfTheInterpretation()
        {
            // Arrange
            var command = new CommandViewModel { Line = "create new task go to the doctor" };
            var resultCommand = new Command
                {
                    Line = "create new task go to the doctor",
                    Verb = "create new task", 
                    Argument = "go to the doctor", 
                    Response = "new task created!"
                };
            var tasksController = GetTaskController();
            interpreter.Setup(i => i.Interpret(command.Line)).Returns(resultCommand);
            // Act
            var jsonResult = tasksController.InterpretCommand(command);
            // Assert
            Assert.AreEqual(expected: resultCommand, actual: jsonResult.Data);
        }

        private TasksController GetTaskController()
        {
            return new TasksController(taskHandler.Object, interpreter.Object);
        }
    }
}