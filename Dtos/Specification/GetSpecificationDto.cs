namespace RentX.Dtos.Specification
{
    public record GetSpecificationDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Created_At { get; set; } = DateTime.Now;
    }
}
