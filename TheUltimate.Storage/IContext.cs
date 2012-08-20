using System.Collections.Generic;
using TheUltimate.Domain.Model;

namespace TheUltimate.Storage
{
    public interface IContext
    {
        IEnumerable<Tag> Tags { get; }
        IEnumerable<Task> Tasks { get; } 
    }
}