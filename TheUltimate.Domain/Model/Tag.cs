using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheUltimate.Domain.Model
{
    public class Tag
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}