using System;
using TheUltimate.Interpreter.Interfaces;
using TheUltimate.Interpreter.Model;

namespace TheUltimate.Interpreter.Concretes
{
    public class CommandInterpreter : IInterpreter
    {
        private readonly IParser parser;
        private readonly ICommandExecuter commandExecuter;

        public CommandInterpreter(IParser parser, ICommandExecuter commandExecuter)
        {
            this.parser = parser;
            this.commandExecuter = commandExecuter;
        }

        public Command Interpret(string line)
        {
            Command command = parser.Parse(line);
            // execute command
            if (command.IsValid)
                commandExecuter.Execute(command);
            // return command so it can be handled in the view via jQuery and affect the UI async
            return command;
        }
    }
}