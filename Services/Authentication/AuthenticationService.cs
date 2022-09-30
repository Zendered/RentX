using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RentX.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RentX.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly DataContext context;
        private readonly IConfiguration config;
        private readonly IHttpContextAccessor contextAccessor;

        public AuthenticationService(DataContext context, IConfiguration config, IHttpContextAccessor contextAccessor)
        {
            this.context = context;
            this.config = config;
            this.contextAccessor = contextAccessor;
        }

        public async Task<ServiceResponse<string>> Login(string userName, string password)
        {
            var res = new ServiceResponse<string>();
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == userName);
            var exists = user is not null;

            if (exists is false)
            {
                res.Success = false;
                res.Message = "Email/Password Incorrect.";
                res.Data = null;
                return res;
            }
            else if (VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt) is false)
            {
                res.Success = false;
                res.Message = "Email/Password Incorrect.";
                res.Data = null;
                return res;
            }

            res.Message = $"Welcome {user.Email.ToLower().ToString().Trim()}";
            res.Data = $"Bearer {CreateToken(user)}";
            return res;
        }

        public async Task<ServiceResponse<Guid?>> Register(User user, string password)
        {
            var res = new ServiceResponse<Guid?>();

            if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(password))
            {
                res.Success = false;
                res.Message = "Email/Password Incorrect.";
                res.Data = null;
                return res;
            }

            if (await EmailExists(user.Email))
            {
                res.Success = false;
                res.Message = "Email/Password Incorrect.";
                res.Data = null;
                return res;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            context.Users.Add(user);
            await context.SaveChangesAsync();
            res.Data = user.Id;
            res.Message = "User created successful";
            return res;
        }

        public async Task<bool> EmailExists(string email)
        {
            var exists = await context.Users.AnyAsync(u => email == u.Email);
            return exists;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computeHash.SequenceEqual(passwordHash);
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
                GetBytes(config["AppSettings:Token"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public Guid GetUserId() => Guid.Parse(
            contextAccessor?.HttpContext?.User
            .FindFirstValue(ClaimTypes.NameIdentifier)
            ?? throw new ArgumentException()
            );
    }
}
