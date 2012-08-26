using TheUltimate.Interpreter.Model;

namespace TheUltimate.Interpreter.Interfaces
{
    public interface ICommandExecuter
    {
        void Execute(Command command);
    }
}