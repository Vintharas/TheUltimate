using System.Collections.Generic;
using System.Data.Entity;
using TheUltimate.Domain.Model;

namespace TheUltimate.Storage
{
    public class Context : DbContext, IContext
    {
        public IDbSet<Tag> Tags { get; set; }
        public IDbSet<Task> Tasks { get; set; }

        static Context()
        {
            InitializeDatabase();
        }

        static private void InitializeDatabase()
        {
            Database.SetInitializer(new TheUltimateDropCreateDbAlways());
        }
    }
}