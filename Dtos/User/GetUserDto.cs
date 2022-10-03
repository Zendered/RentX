using RentX.Dtos.Rental;

namespace RentX.Dtos.User
{
    public class GetUserDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string DriverLicense { get; set; } = string.Empty;
        public bool Admin { get; set; } = false;
        public string? Avatar { get; set; } = string.Empty;
        public DateTime Created_At { get; set; } = DateTime.Now;
        public GetRentalDto Rentals { get; set; } = new GetRentalDto();
    }
}
