using System;
using TheUltimate.Interpreter.Interfaces;
using TheUltimate.Interpreter.Model;

namespace TheUltimate.Interpreter.Concretes
{
    public class CommandInterpreter : IInterpreter
    {
        private readonly IParser parser;

        public CommandInterpreter(IParser parser)
        {
            this.parser = parser;
        }

        public Command Interpret(string line)
        {
            Command command = parser.Parse(line);
            // execute command

            // return command so it can be handled in the view via jQuery and affect the UI async
            return command;
        }
    }
}