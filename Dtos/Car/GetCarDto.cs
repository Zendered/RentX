namespace RentX.Dtos.Car
{
    public record GetCarDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Daily_Rate { get; set; }
        public bool Available { get; set; } = true;
        public string LicensePlate { get; set; } = string.Empty;
        public int FineAmount { get; set; }
        public string Brand { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
        public DateTime Created_At { get; set; } = DateTime.Now;
    }
}
