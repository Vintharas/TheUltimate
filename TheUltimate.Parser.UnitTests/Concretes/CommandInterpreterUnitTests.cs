using Moq;
using NUnit.Framework;
using TheUltimate.Interpreter.Concretes;
using TheUltimate.Interpreter.Interfaces;

namespace TheUltimate.Interpreter.UnitTests.Concretes
{
    [TestFixture]
    public class CommandInterpreterUnitTests
    {
        private Mock<IParser> parser;

        [SetUp]
        public void SetUp()
        {
            parser = new Mock<IParser>();
        }

        [Test]
        public void Interpret_WhenGivenALineToInterpret_ShouldParseItUsingTheParser()
        {
            // Arrange
            string line = "create new task";
            var interpreter = GetInterpreter();
            // Act
            interpreter.Interpret(line);
            // Assert
            parser.Verify(x => x.Parse(line));
        }

        private CommandInterpreter GetInterpreter()
        {
            return new CommandInterpreter(parser.Object);
        }
    }
}