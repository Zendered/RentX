using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentX.Data;
using RentX.Dtos.Rental;
using RentX.Services.Cars;
using RentX.Tools.IsValidData;
using System.Data;
using System.Security.Claims;

namespace RentX.Services.Rentals
{
    public class RentalService : IRentalService
    {
        private readonly DataContext ctx;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor contextAccessor;
        private readonly ICarService carService;

        public RentalService(DataContext ctx, IMapper mapper, IHttpContextAccessor contextAccessor, ICarService carService)
        {
            this.ctx = ctx;
            this.mapper = mapper;
            this.contextAccessor = contextAccessor;
            this.carService = carService;
        }

        public async Task<ServiceResponse<GetRentalDto>> CreateRentalAsync(AddRentalDto data)
        {
            var res = new ServiceResponse<GetRentalDto>();

            try
            {
                var rent = mapper.Map<Rental>(data);

                var returnDate = DateTime.Compare(DateTime.Now, data.Expected_Return_Date);

                var today = DateTime.Now.Day;
                var month = DateTime.Now.Month;
                var year = DateTime.Now.Year;

                var sla = data.Expected_Return_Date.Day;
                var sla1 = data.Expected_Return_Date.Month;
                var sla2 = data.Expected_Return_Date.Year;

                var expectedDate = $"{sla}/{sla1}/{sla2}";

                var lessThen24Hr = DateTime.Parse(expectedDate) < DateTime.Parse($"{today}/{month}/{year}");

                if (returnDate < 0 || lessThen24Hr)
                {
                    res.Success = false;
                    res.Data = null;
                    res.Message = "Invalid return time";
                    return res;
                }

                var rentExists = await ctx.Rentals
                    .FirstOrDefaultAsync(rent => rent.UserId == GetUserId());

                if (rentExists is not null)
                {
                    res.Success = false;
                    res.Data = null;
                    res.Message = "User already has a rent";
                    return res;
                }

                rent.UserId = GetUserId();
                await carService.updateAvailable(data.CarId, false);

                await ctx.Rentals.AddAsync(rent);
                await ctx.SaveChangesAsync();

                var returnRent = mapper.Map<GetRentalDto>(rent);
                res.Data = returnRent;
                res.Message = "Rent made successfully";
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Data = null;
                res.Message = ex.Message;
            }
            return res;
        }

        public async Task<ServiceResponse<GetRentalDto>> DevolutionRentalAsync(GetRentalDto data)
        {
            var res = new ServiceResponse<GetRentalDto>();
            try
            {
                var isValid = IsValidData.IsValid(data.Id.ToString(), data.UserId.ToString(), data.UserId.ToString());

                if (isValid is false)
                {
                    res.Success = false;
                    res.Data = null;
                    res.Message = "Invalid Data";
                    return res;
                }

                var rental = await ctx.Rentals.FirstOrDefaultAsync(rental => rental.Id == data.Id);

                if (rental is null)
                {
                    res.Success = false;
                    res.Data = null;
                    res.Message = "Rental doest exists";
                    return res;
                }
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Data = null;
                res.Message = ex.Message;
            }
            return res;
        }

        public async Task<ServiceResponse<GetRentalDto>> FindOpenRentalByCarAsync(Guid carId)
        {
            var res = new ServiceResponse<GetRentalDto>();

            try
            {
                var carAvailable = await ctx.Cars
                    .Where(ctx => ctx.Rental.End_Date == null)
                    .FirstOrDefaultAsync(car => car.Id == carId);

                if (carAvailable is null)
                {
                    res.Data = null;
                    res.Message = "Car is unavailable";
                    res.Success = false;
                    return res;
                }
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Data = null;
                res.Message = ex.Message;
            }

            return res;
        }

        public async Task<ServiceResponse<GetRentalDto>> FindOpenRentalByUserAsync(Guid userId)
        {
            var res = new ServiceResponse<GetRentalDto>();

            try
            {
                var rentalOpenToUser = await ctx.Rentals
                    .Where(ctx => ctx.User.Id == userId)
                    .FirstOrDefaultAsync(rent => rent.End_Date == null);

                if (rentalOpenToUser is null)
                {
                    res.Data = null;
                    res.Message = "There's a rental in progress for user!";
                    res.Success = false;
                    return res;
                }
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Data = null;
                res.Message = ex.Message;
            }
            return res;
        }

        public Task<ServiceResponse<GetRentalDto>> FindRentalByIdAsync(GetRentalDto rentalId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetRentalDto>> FindRentalByUserAsync(GetRentalDto userId)
        {
            throw new NotImplementedException();
        }

        public Guid GetUserId() => Guid.Parse(
            contextAccessor?.HttpContext?.User
            .FindFirstValue(ClaimTypes.NameIdentifier)
            ?? throw new ArgumentException());
    }
}
