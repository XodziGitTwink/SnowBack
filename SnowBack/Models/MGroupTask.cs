namespace SnowBack.Models
{
    public class MGroupTask
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<MTask> Tasks { get; set; }
    }
}
