using System.Collections.Generic;
using TheUltimate.Domain.Model;

namespace TheUltimate.Storage
{
    public interface IContext
    {
        IList<Tag> Tags { get; }
        IList<Task> Tasks { get; }
        void SaveContext();
    }
}