﻿using RentX.Dtos.Car;
using RentX.Dtos.User;

namespace RentX.Dtos.Rental
{
    public record GetRentalDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CarId { get; set; }
        public GetCarDto? Car { get; set; }
        public Guid UserId { get; set; }
        public GetUserDto? User { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public DateTime Expected_Return_Date { get; set; }
        public int Total { get; set; }
        public DateTime Updated_At { get; set; } = DateTime.Now;
        public DateTime Created_At { get; set; } = DateTime.Now;
    }
}
