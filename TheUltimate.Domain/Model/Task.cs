namespace TheUltimate.Domain.Model
{
    public class Task
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Tag Tag { get; set; }
    }
}