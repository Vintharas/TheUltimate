using System.Collections.Generic;
using TheUltimate.Interpreter.Model;

namespace TheUltimate.Interpreter.Concretes
{
    public class VerbManager
    {
        public static IEnumerable<Verb> Verbs { get; private set; }

        static VerbManager()
        {
            Verbs = new List<Verb>
                {
                    new Verb { Name = "create new task", Response = "new task created!"},
                    new Verb { Name = "new task", Response = "new task created!"}
                };
        }
    }
}