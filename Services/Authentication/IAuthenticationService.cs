namespace RentX.Services.Authentication
{
    public interface IAuthenticationService
    {
        public Task<ServiceResponse<Guid?>> Register(User user, string password);
        public Task<ServiceResponse<string>> Login(string userName, string password);
        Task<bool> EmailExists(string email);
    }
}
