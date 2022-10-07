using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentX.Data;
using RentX.Dtos.Rental;
using System.Data;
using System.Security.Claims;

namespace RentX.Services.Rentals
{
    public class RentalService : IRentalService
    {
        private readonly DataContext ctx;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor contextAccessor;

        public RentalService(DataContext ctx, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            this.ctx = ctx;
            this.mapper = mapper;
            this.contextAccessor = contextAccessor;
        }

        int minHour = 24;
        public async Task<ServiceResponse<GetRentalDto>> CreateRentalAsync(AddRentalDto data)
        {
            var res = new ServiceResponse<GetRentalDto>();

            try
            {
                var rent = mapper.Map<Rental>(data);

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

        private int CompareInHours(DateTime startDate, DateTime endDate)
        {
            var diference = DateTime.Compare(startDate, endDate);
            return diference;
        }

        public Guid GetUserId() => Guid.Parse(
            contextAccessor?.HttpContext?.User
            .FindFirstValue(ClaimTypes.NameIdentifier)
            ?? throw new ArgumentException());
    }
}
