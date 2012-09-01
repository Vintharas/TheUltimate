using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
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
        public void SaveTask_WhenGivenATask_ShouldSaveItViaContext()
        {
            // Arrange
            var task = new Task();
            var taskHandler = GetTaskHandler();
            // Act
            taskHandler.SaveTasks();
            // Assert
            context.Verify(x => x.SaveChanges());
        }

        private TaskHandler GetTaskHandler()
        {
            return new TaskHandler(context.Object);
        }
    }
}