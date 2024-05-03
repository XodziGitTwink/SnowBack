namespace SnowBack.Models
{
    public class MTask
    {
        public int ParentId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? Location { get; set; }

        public int Executor { get; set; }

        public string Priority {  get; set; }

        public bool IsGroup {  get; set; }

        public DateTime Created { get; set; }

        public DateTime PlanTimeToFinish { get; set; }
    }
}
