global using RentX.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RentX.Data;
using RentX.Services.Authentication;
using RentX.Services.Cars;
using RentX.Services.Categories;
using RentX.Services.Specifications;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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

builder.Services.AddHttpContextAccessor();
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.Development", true)
    .AddUserSecrets(typeof(Program).Assembly, true)
    .Build();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ISpeficicationService, SpeficicationService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(config["AppSettings:Token"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

//var ConnectionString = config["ConnectionStrings:DefaultConnection"];
//builder.Services.AddDbContext<DataContext>(option => option.UseSqlServer(ConnectionString));

builder.Services
    .AddDbContext<DataContext>(
    option =>
    option.UseInMemoryDatabase("rentxdb")); // Test Db 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//DatabaseManagementService.MigrationInitialisation(app);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
