namespace SnowBack.Models
{
    public class DGroupTask
    {
        public int Id { get; set; }

        public string? Code { get; set; }

        public string Name { get; set; } = null!;

        public DateTime Created { get; set; }
    }
}
