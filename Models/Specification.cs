namespace RentX.Models
{
    public class Specification
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Created_At { get; set; } = DateTime.Now;
    }
}
