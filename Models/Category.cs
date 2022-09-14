namespace RentX.Models
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Car? Car { get; set; }
        public DateTime Created_At { get; set; } = DateTime.Now;
    }
}
