namespace SnowBack.Models
{
    public class MGroupTask
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Code { get; set; }

        public int? Creator { get; set; }

        public DateTime Created { get; set; }

        public List<MTask> Tasks { get; set; }
    }
}
