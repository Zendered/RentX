using AutoMapper;
using CsvHelper;
using RentX.Dtos.Specification;
using System.Globalization;

namespace RentX.Services.Specifications
{
    public record SpeficicationService(IMapper Mapper) : ISpeficicationService
    {
        public async Task<ServiceResponse<GetSpecificationDto>> AddSpecificationAsync(List<AddSpecificationDto> newSpecification)
        {
            var res = new ServiceResponse<GetSpecificationDto>();

            try
            {
                var specification = Mapper.Map<List<Specification>>(newSpecification);
                var currentFile = Directory.GetCurrentDirectory();

                using (var writer = new StreamWriter($"{currentFile}/specification.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    await csv.WriteRecordsAsync(specification);
                    await writer.FlushAsync();
                }

                res.Message = "File uploaded successfully";
                res.Data = null;

                Console.WriteLine(res);
                return res;
            }
            catch (Exception ex)
            {

                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public Task<ServiceResponse<GetSpecificationDto>> GetSpecificationByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
