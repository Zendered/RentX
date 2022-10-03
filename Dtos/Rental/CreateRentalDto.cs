using RentX.Dtos.Car;
using RentX.Dtos.User;

namespace RentX.Dtos.Rental
{
    public class CreateRentalDto
    {
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
        public GetCarDto Car { get; set; } = new GetCarDto();
        public GetUserDto User { get; set; } = new GetUserDto();
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public DateTime Expected_Return_Date { get; set; }
        public int Total { get; set; }
    }
}
