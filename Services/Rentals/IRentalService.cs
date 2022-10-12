using RentX.Dtos.Rental;

namespace RentX.Services.Rentals
{
    public interface IRentalService
    {
        Task<ServiceResponse<GetRentalDto>> FindOpenRentalByCarAsync(Guid carId);
        Task<ServiceResponse<GetRentalDto>> FindOpenRentalByUserAsync(Guid userId);
        Task<ServiceResponse<GetRentalDto>> CreateRentalAsync(AddRentalDto data);
        Task<ServiceResponse<GetRentalDto>> FindRentalByIdAsync(GetRentalDto rentalId);
        Task<ServiceResponse<List<GetRentalDto>>> FindRentalByUserAsync();
        Task<ServiceResponse<GetRentalDto>> DevolutionRentalAsync(RentalsDevolutionDto data);

    }
}
