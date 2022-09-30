using AutoMapper;
using RentX.Data;
using RentX.Dtos.Specification;
using RentX.Tools.IsValidData;

namespace RentX.Services.Specifications
{
    public class SpeficicationService : ISpeficicationService
    {
        private readonly DataContext ctx;
        private readonly IMapper mapper;

        public SpeficicationService(DataContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public ServiceResponse<GetSpecificationDto> AddSpecificationAsync(AddSpecificationDto newSpecification)
        {
            var res = new ServiceResponse<GetSpecificationDto>();

            try
            {
                bool invalidData = IsValidData.IsValid(newSpecification.Name, newSpecification.Description);
                if (invalidData)
                {
                    res.Data = null;
                    res.Message = "Invalid Name/Description, please try again";
                    return res;
                }

                var specification = mapper.Map<Specification>(newSpecification);
                var exists = ctx.Specifications.Any(spec => spec.Name == specification.Name);

                if (exists)
                {
                    res.Data = null;
                    res.Message = "That specification already exists";
                    return res;
                }

                ctx.Specifications.Add(specification);
                ctx.SaveChanges();

                var getSpecification = ctx.Specifications.Find(specification.Id);
                var returnSpecification = mapper.Map<GetSpecificationDto>(getSpecification);

                res.Message = "Specification created";
                res.Data = returnSpecification;
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }
    }
}

