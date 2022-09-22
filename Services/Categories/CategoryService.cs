using AutoMapper;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using RentX.Data;
using RentX.Dtos.Category;
using System.Globalization;

namespace RentX.Services.Categories
{
    public record CategoryService(DataContext CategoryContext, IMapper Mapper) : ICategoryService
    {
        public async Task<ServiceResponse<GetCategoryDto>> AddCategoryAsync(AddCategoryDto newCategory)
        {
            var res = new ServiceResponse<GetCategoryDto>();

            try
            {
                var isParamterInvalid =
                    string.IsNullOrWhiteSpace(newCategory.Name) ||
                    string.IsNullOrWhiteSpace(newCategory.Description);

                if (isParamterInvalid)
                {
                    res.Success = false;
                    res.Data = null;
                    res.Message = "Invalid Name/Description, please try again";
                    return res;
                };

                var category = Mapper.Map<Category>(newCategory);
                var exists = await CategoryContext.Categories.FirstOrDefaultAsync(c => c.Name == category.Name);

                if (exists is not null)
                {
                    res.Data = null;
                    res.Message = "That category already exists";
                    res.Success = false;
                    return res;
                };

                await CategoryContext.Categories.AddAsync(category);
                await CategoryContext.SaveChangesAsync();

                res.Data = Mapper.Map<GetCategoryDto>(category);
                res.Message = "Category created";
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public async Task<ServiceResponse<GetCategoryDto>> AddCategoryCSVFileAsync(IFormFile categoryFile)
        {
            var res = new ServiceResponse<GetCategoryDto>();

            try
            {
                var currentFile = Directory.GetCurrentDirectory();
                using (var file = File.Create($"{DateTime.Now:dd-MM-yy:HH:mm:ss}-categoriesList.csv"))
                {
                    categoryFile.CopyTo(file);
                    await file.FlushAsync();
                }

                using (var reader = new StreamReader($"{currentFile}/{DateTime.Now:dd-MM-yy:HH:mm:ss}-categoriesList.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<GetCategoryDto>().ToList();
                    foreach (var record in records)
                    {
                        var category = Mapper.Map<Category>(record);
                        await CategoryContext.Categories.AddAsync(category);
                        await CategoryContext.SaveChangesAsync();
                    }
                }

                res.Data = null;
                res.Message = "File uploaded successfully";
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public async Task<ServiceResponse<GetCategoryDto>> GetCategoryByIdAsync(Guid id)
        {
            var res = new ServiceResponse<GetCategoryDto>();

            try
            {
                var category = await CategoryContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

                if (category is null)
                {
                    res.Success = false;
                    res.Message = "Category not found";
                    res.Data = null;
                    return res;
                };

                res.Data = Mapper.Map<GetCategoryDto>(category);
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public ServiceResponse<List<GetCategoryDto>> GetCategoryCSVFile(string fileName)
        {
            var res = new ServiceResponse<List<GetCategoryDto>>();
            try
            {
                var currentFile = Directory.GetCurrentDirectory();

                using var reader = new StreamReader($"{currentFile}/{fileName}.csv");
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<GetCategoryDto>().ToList();
                res.Data = records;
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public async Task<ServiceResponse<List<GetCategoryDto>>> GetAllCategoriesAsync()
        {
            var res = new ServiceResponse<List<GetCategoryDto>>();

            try
            {
                var category = await CategoryContext.Categories.ToListAsync();
                res.Data = Mapper.Map<List<GetCategoryDto>>(category);
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public async Task<ServiceResponse<GetCategoryDto>> RemoveCategoryAsync(Guid id)
        {
            var res = new ServiceResponse<GetCategoryDto>();

            try
            {
                var category = await CategoryContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

                if (category is null)
                {
                    res.Success = false;
                    res.Message = "Category not found";
                    res.Data = null;
                    return res;
                };

                CategoryContext.Remove(category);
                await CategoryContext.SaveChangesAsync();

                res.Data = Mapper.Map<GetCategoryDto>(category);
                res.Message = "Category deleted";
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
