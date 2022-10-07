namespace RentX.Dtos.Rental
{
    public record AddRentalDto
    {
        public Guid CarId { get; set; }
        public DateTime Expected_Return_Date { get; set; }
    }
}
