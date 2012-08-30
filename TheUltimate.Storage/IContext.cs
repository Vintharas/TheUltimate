using System;
using System.Data.Entity;
using TheUltimate.Domain.Model;

namespace TheUltimate.Storage
{
    public interface IContext : IDisposable
    {
        IDbSet<Tag> Tags { get; set; }
        IDbSet<Task> Tasks { get; set; }
        int SaveChanges();
    }
}