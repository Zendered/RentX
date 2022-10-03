namespace RentX.Models
{
    public class Rental
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CarId { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; } = Guid.NewGuid();
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public DateTime Expected_Return_Date { get; set; }
        public int Total { get; set; }
        public DateTime Updated_At { get; set; } = DateTime.Now;
        public DateTime Created_At { get; set; } = DateTime.Now;
    }
}
