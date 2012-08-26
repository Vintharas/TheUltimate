using TheUltimate.Interpreter.Model;

namespace TheUltimate.Interpreter.Interfaces
{
    public interface IInterpreter
    {
        Command Interpret(string line);
    }
}