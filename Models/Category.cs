namespace RentX.Models
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CarId { get; set; } = Guid.NewGuid();
        public string ImageName { get; set; } = string.Empty;
        public DateTime Created_At { get; set; } = DateTime.Now;
    }
}
