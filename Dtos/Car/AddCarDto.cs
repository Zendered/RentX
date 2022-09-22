namespace RentX.Dtos.Car
{
    public class AddCarDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Daily_Rate { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public int FineAmount { get; set; }
        public Guid? CategoryId { get; set; }
        public string Brand { get; set; } = string.Empty;
    }
}
