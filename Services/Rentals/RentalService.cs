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

                int returnDate = DateTime.Compare(data.Expected_Return_Date, DateTime.UtcNow);
                bool lessThen24Hr = IsValidDate(data);

                if (returnDate < 0 || lessThen24Hr is false)
                {
                    res.Success = false;
                    res.Data = null;
                    res.Message = "Invalid return time";
                    return res;
                }

                var rentExists = await ctx.Rentals
                    .Where(end => end.End_Date.Year == 001)
                    .FirstOrDefaultAsync(rent => rent.UserId == GetUserId());

                if (rentExists is not null)
                {
                    res.Success = false;
                    res.Data = null;
                    res.Message = "User already has a rent";
                    return res;
                }

                var carIsAvailable = await ctx.Cars.FirstOrDefaultAsync(car => car.Id == data.CarId);
                if (carIsAvailable.Available is false || carIsAvailable is null)
                {
                    res.Success = false;
                    res.Data = null;
                    res.Message = "Car is unavailable";
                    return res;
                }

                rent.Start_Date = DateTime.UtcNow;
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

        public async Task<ServiceResponse<GetRentalDto>> DevolutionRentalAsync(RentalsDevolutionDto data)
        {
            var res = new ServiceResponse<GetRentalDto>();
            try
            {
                var invalidData = IsValidData.IsValid(data.Id.ToString(), data.UserId.ToString(), data.CarId.ToString());

                if (invalidData)
                {
                    res.Success = false;
                    res.Data = null;
                    res.Message = "Invalid Data";
                    return res;
                }

                data.UserId = GetUserId();
                var rental = await ctx.Rentals.FirstOrDefaultAsync(rental => rental.Id == data.Id);

                if (rental is null)
                {
                    res.Success = false;
                    res.Data = null;
                    res.Message = "Rental doest exists";
                    return res;
                }

                var car = await ctx.Cars.FirstOrDefaultAsync(car => car.Id == rental.CarId);

                if (car is null)
                {
                    res.Success = false;
                    res.Data = null;
                    res.Message = "Car doest exists";
                    return res;
                }

                var daily = rental.Expected_Return_Date.Day - DateTime.UtcNow.Day;
                if (daily <= 0)
                {
                    daily = 1;
                }

                int total = 0;

                var delay = DateTime.Compare(DateTime.UtcNow, rental.Expected_Return_Date);
                if (delay > 0)
                {
                    var calculateFine = DateTime.UtcNow.Day % rental.Expected_Return_Date.Day;
                    total = calculateFine;
                }

                total += daily * car.Daily_Rate;
                rental.Total = total;
                rental.End_Date = DateTime.UtcNow;

                var addRental = mapper.Map<AddRentalDto>(rental);
                var rentalToReturn = mapper.Map<GetRentalDto>(rental);
                await CreateRentalAsync(addRental);
                await carService.updateAvailable(car.Id, true);
                await ctx.SaveChangesAsync();

                res.Data = rentalToReturn;
                res.Message = "Car returned";
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

        private static bool IsValidDate(AddRentalDto data)
        {
            var day = DateTime.Now.Day;
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;

            var wrongDay = data.Expected_Return_Date.Day < day;
            var wrongMonth = data.Expected_Return_Date.Month < month;
            var wrongYear = data.Expected_Return_Date.Year < year;

            if (wrongDay || wrongMonth || wrongYear) return false;

            return true;
        }
        public Guid GetUserId() => Guid.Parse(
            contextAccessor?.HttpContext?.User
            .FindFirstValue(ClaimTypes.NameIdentifier)
            ?? throw new ArgumentException());
    }
}
