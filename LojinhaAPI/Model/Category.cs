namespace LojinhaAPI.Model
{
    public class Category
    {
        public int ControlId { get; set; }
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Status Status { get; set; }
    }
}
