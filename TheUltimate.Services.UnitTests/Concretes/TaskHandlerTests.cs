using System.Collections.Generic;
using System.Collections.Specialized;
using Moq;
using NUnit.Framework;
using TheUltimate.Domain.Model;
using TheUltimate.Services.Concretes;
using TheUltimate.Storage;

namespace TheUltimate.Services.UnitTests.Concretes
{
    [TestFixture]
    public class TaskHandlerTests
    {
        private Mock<IContext> context;

        [SetUp]
        public void SetUp()
        {
            context = new Mock<IContext>();
        }

        [Test]
        public void GetTasks_ShouldReturnAllTasksViaContext()
        {
            // Arrange
            var taskHandler = GetTaskHandler();
            var expectedTasks = new List<Task> {new Task()};
            context.Setup(c => c.Tasks).Returns(expectedTasks);
            // Act
            var actualTasks = taskHandler.GetTasks();
            // Assert
            Assert.AreEqual(expectedTasks, actualTasks);
        }

        [Test]
        public void CreateNewTask_ShouldCreateANewTaskAndAddItToTheContext()
        {
            // Arrange
            var taskHandler = GetTaskHandler();
            var tasksInContext = new List<Task>();
            context.Setup(c => c.Tasks).Returns(tasksInContext);
            // Act
            var task = taskHandler.CreateNewTask();
            // Assert
            Assert.Contains(expected: task, actual: tasksInContext);
        }
        
        [Test]
        public void SaveTask_WhenGivenATask_ShouldSaveItViaContext()
        {
            // Arrange
            var task = new Task();
            var taskHandler = GetTaskHandler();
            // Act
            taskHandler.SaveTasks();
            // Assert
            context.Verify(x => x.SaveContext());
        }

        private TaskHandler GetTaskHandler()
        {
            return new TaskHandler(context.Object);
        }
    }
}