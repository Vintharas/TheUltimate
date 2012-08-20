using System.Collections.Generic;

namespace TheUltimate.Domain.Model
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}