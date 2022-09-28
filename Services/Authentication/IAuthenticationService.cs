namespace RentX.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<ServiceResponse<Guid?>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string userName, string password);
        Task<bool> EmailExists(string email);
        Guid GetUserId();
    }
}
