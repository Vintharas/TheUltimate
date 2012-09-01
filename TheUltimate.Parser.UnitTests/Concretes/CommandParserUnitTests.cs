using NUnit.Framework;
using TheUltimate.Interpreter.Concretes;
using TheUltimate.Interpreter.Model;

namespace TheUltimate.Interpreter.UnitTests.Concretes
{
    [TestFixture]
    public class CommandParserUnitTests
    {

        [Test]
        public void Parse_WhenGivenACreateNewTaskCommand_ShouldParseItAppropriately()
        {
            // Arrange
            var line = "create new task do the dishes";
            var parser = GetParser();
            // Act
            var command = parser.Parse(line);
            // Assert
            Command expectedCommand = new Command
                {
                    Line = line,
                    Verb = "create new task",
                    Argument = "do the dishes",
                    Response = "new task created!",
                    IsValid = true
                };
            Assert.AreEqual(expected: expectedCommand, actual: command);
        }

        [Test]
        public void Parse_WhenGivenANewTaskCommand_ShouldParseItAppropriately()
        {
            // Arrange
            var line = "new task do the dishes";
            var parser = GetParser();
            // Act
            var command = parser.Parse(line);
            // Assert
            Command expectedCommand = new Command
                {
                    Line = line,
                    Verb = "new task",
                    Argument = "do the dishes",
                    Response = "new task created!",
                    IsValid = true
                };
            Assert.AreEqual(expected: expectedCommand, actual: command);
        }

        [Test]
        public void Parse_WhenGivenACompleteTaskCommand_ShouldParseItAppropriately()
        {
            // Arrange
            var line = "complete task do the dishes";
            var parser = GetParser();
            // Act
            var command = parser.Parse(line);
            // Assert
            Command expectedCommand = new Command
            {
                Line = line,
                Verb = "complete task",
                Argument = "do the dishes",
                Response = "task completed!",
                IsValid = true
            };
            Assert.AreEqual(expected: expectedCommand, actual: command);
        }

        [Test]
        public void Parse_WhenGivenACompleteCommand_ShouldParseItAppropriately()
        {
            // Arrange
            var line = "complete do the dishes";
            var parser = GetParser();
            // Act
            var command = parser.Parse(line);
            // Assert
            Command expectedCommand = new Command
            {
                Line = line,
                Verb = "complete",
                Argument = "do the dishes",
                Response = "task completed!",
                IsValid = true
            };
            Assert.AreEqual(expected: expectedCommand, actual: command);
        }

        [Test]
        public void Parse_WhenGivenACompleteCommandWithANumberArgument_ShouldParseItAppropriately()
        {
            // Arrange
            var line = "complete #5";
            var parser = GetParser();
            // Act
            var command = parser.Parse(line);
            // Assert
            Command expectedCommand = new Command
            {
                Line = line,
                Verb = "complete",
                Argument = "#5",
                Response = "task completed!",
                IsValid = true
            };
            Assert.AreEqual(expected: expectedCommand, actual: command);
        }

        private CommandParser GetParser()
        {
            return new CommandParser();
        }
    }
}