using System.Collections.Generic;
using TheUltimate.Domain.Model;

namespace TheUltimate.Storage
{
    public class Context
    {
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Task> Tasks { get; set; }

        public Context()
        {
            Tags = new List<Tag>();
            Tasks = new List<Task>();
        }
    }
}