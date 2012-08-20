using System.Collections.Generic;
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

        private TaskHandler GetTaskHandler()
        {
            return new TaskHandler(context.Object);
        }
    }
}