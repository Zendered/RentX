global using RentX.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RentX.Data;
using RentX.Services.Authentication;
using RentX.Services.Cars;
using RentX.Services.Categories;
using RentX.Services.Rentals;
using RentX.Services.Specifications;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
#region Swagger config
builder.Services.AddSwaggerGen(config =>
{
    config.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme, e.g \" Bearer {token} \"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    config.OperationFilter<SecurityRequirementsOperationFilter>();
    config.EnableAnnotations();

    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "RentX",
        Version = "v1",
        Description = "Rent for cars API"
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    config.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
#endregion

builder.Services.AddHttpContextAccessor();

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.Development", true)
    .AddUserSecrets(typeof(Program).Assembly, true)
    .Build();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

#region Interfaces
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ISpeficicationService, SpeficicationService>();
builder.Services.AddScoped<IRentalService, RentalService>();
#endregion

#region AuthenticationJwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(builder.Configuration["AppSettings:Token"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
#endregion

#region Database SqlServer Connection

var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DataContext>(option => option.UseSqlServer(connectionString));

#endregion

#region Database MemoryDatabase Connection

//builder.Services
//    .AddDbContext<DataContext>(
//    option =>
//option.UseInMemoryDatabase("rentxdb")); // Test Db 

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

DatabaseManagementService.MigrationInitialisation(app);

app.Run();
