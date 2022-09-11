namespace RentX.Dtos.Car
{
    public class AddCarDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Daily_Rate { get; set; }
        public bool Available { get; set; } = true;
        public string LicensePlate { get; set; } = string.Empty;
        public int FineAmount { get; set; }
        public string Brand { get; set; } = string.Empty;
    }
}
