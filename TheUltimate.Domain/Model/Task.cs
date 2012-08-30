
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TheUltimate.Domain.Model
{
    
    public class Task
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Number")]
        public int Number { get; set; }
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        public Tag Tag { get; set; }
    }
}