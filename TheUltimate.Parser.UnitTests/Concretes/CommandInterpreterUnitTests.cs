using Moq;
using NUnit.Framework;
using TheUltimate.Interpreter.Concretes;
using TheUltimate.Interpreter.Interfaces;
using TheUltimate.Interpreter.Model;

namespace TheUltimate.Interpreter.UnitTests.Concretes
{
    [TestFixture]
    public class CommandInterpreterUnitTests
    {
        private Mock<IParser> parser;
        private Mock<ICommandExecuter> executer;

        [SetUp]
        public void SetUp()
        {
            parser = new Mock<IParser>();
            executer = new Mock<ICommandExecuter>();
        }

        [Test]
        public void Interpret_WhenGivenALineToInterpret_ShouldParseItUsingTheParser()
        {
            // Arrange
            string line = "create new task";
            var command = new Command();
            parser.Setup(p => p.Parse(line)).Returns(command);
            var interpreter = GetInterpreter();
            // Act
            interpreter.Interpret(line);
            // Assert
            parser.Verify(x => x.Parse(line));
        }

        [Test]
        public void Interpret_WhenGivenALineToInterpret_ShouldExecuteIt()
        {
            // Arrange
            string line = "create new task do the laundry";
            var command = new Command
                {
                    Verb = "create new task",
                    Argument = "do the laundry",
                    Response = "new task created!",
                    Line = "create new task do the laundry",
                    IsValid = true
                };
            parser.Setup(p => p.Parse(line)).Returns(command);
            var interpreter = GetInterpreter();
            // Act
            interpreter.Interpret(line);
            // Assert
            executer.Verify(e => e.Execute(command));
        }

        [Test]
        public void Interpret_WhenGivenALineToInterpretAndWasntParsedCorrectly_ShouldNotExecuteAnyCommand()
        {
            // Arrange
            string line = "line that cannot be parsed";
            var command = new Command
            {
                IsValid = false
            };
            parser.Setup(p => p.Parse(line)).Returns(command);
            var interpreter = GetInterpreter();
            // Act
            interpreter.Interpret(line);
            // Assert
            executer.Verify(e => e.Execute(command), Times.Never());
        }

        private CommandInterpreter GetInterpreter()
        {
            return new CommandInterpreter(parser.Object, executer.Object);
        }
    }
}