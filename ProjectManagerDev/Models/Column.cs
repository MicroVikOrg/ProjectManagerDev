namespace ProjectManagerDev.Models
{
    public class Column
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public Board Board { get; set; }
        public int BoardId { get; set; }
    }
}