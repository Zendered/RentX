namespace RentX.Dtos.Rental
{
    public record GetRentalDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CarId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime Expected_Return_Date { get; set; }
    }
}
