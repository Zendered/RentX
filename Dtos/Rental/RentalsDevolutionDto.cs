namespace RentX.Dtos.Rental
{
    public class RentalsDevolutionDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CarId { get; set; }

        public Guid UserId { get; set; }
    }
}
