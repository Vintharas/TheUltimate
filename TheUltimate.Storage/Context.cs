﻿using System.Collections.Generic;
using TheUltimate.Domain.Model;

namespace TheUltimate.Storage
{
    public class Context : IContext
    {
        public IList<Tag> Tags { get; private set; }
        public IList<Task> Tasks { get; private set; }
        
        public void SaveContext()
        {
            // Save changes XD   
        }

        public Context()
        {
            Tags = new List<Tag>();
            Tasks = new List<Task>
                {
                    new Task {Number = 1, Name = "Do the Laundry", Description = "Do the Laundry. Remember to use softening!"},
                    new Task {Number = 2, Name = "Go to the gym"},
                    new Task {Number = 3, Name = "Buy roses for anniversary"}
                };
        }
    }
}