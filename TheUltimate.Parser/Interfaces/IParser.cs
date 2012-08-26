using TheUltimate.Interpreter.Model;

namespace TheUltimate.Interpreter.Interfaces
{
    public interface IParser
    {
        Command Parse(string line);
    }
}