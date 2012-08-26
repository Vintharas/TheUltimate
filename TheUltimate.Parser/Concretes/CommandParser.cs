using System;
using TheUltimate.Interpreter.Interfaces;
using TheUltimate.Interpreter.Model;
using System.Linq;

namespace TheUltimate.Interpreter.Concretes
{
    public class CommandParser : IParser
    {

        public Command Parse(string line)
        {
            if (HasVerb(line))
            {
                var verb = ExtractVerb(line);
                return new Command
                    {
                        Line = line,
                        Verb = verb.Name,
                        Argument = ExtractArgument(line, verb),
                        Response = verb.Response,
                        IsValid = true
                    };
            }
            return new Command {Response = "Couldn't parse that command! I'm sorry :("};
        }

        private bool HasVerb(string line)
        {
            return VerbManager.Verbs.Any(verb => line.Contains(verb.Name));
        }

        private Verb ExtractVerb(string line)
        {
            return VerbManager.Verbs.First(verb => line.Contains(verb.Name));
        }

        private string ExtractArgument(string line, Verb verb)
        {
            return line.Replace(verb.Name, "").Trim();
        }


    }
}